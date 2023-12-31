using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawController : MonoBehaviour
{
    public static bool is_moving = false;
    // Transform of the player
    public Transform player;

    // Transform of the bed the user will sleep in
    public Transform player_bed;

    // Transform of the reset position for the claw
    public Transform reset_position;

    // Transform for end of the claw
    public Transform claw_end;

    public Transform claw_pointer_base;
    public ClawJoint claw_base;

    // Transform to keep track of the transform being targeted by the claw
    private Transform curr_target;

    public static Vector3 claw_position = new Vector3(0f,0f,0f);

    public float rotate_speed = 5f;
    public float kinematic_speed;
    public int steps = 20;

    public float threshhold = 0.5f;


    /*
        Below are public functions used to change behaviour of the object
    */
    public void targetPlayer(float delay) {
        StartCoroutine(changeTarget(player, delay));
    }

    public void targetBed(float delay) {
        StartCoroutine(changeTarget(player_bed, delay));
    }

    public void targetReset(float delay) {
        StartCoroutine(changeTarget(reset_position, delay));
    }
    /*
        End of public functions
    */



    /*
        Below are private functions used internally to change the state of the claw
    */

    // Changes the claw's target after delay seconds
    private IEnumerator changeTarget(Transform target, float delay) {
        yield return new WaitForSeconds(delay);
        curr_target = target;
    }

    private float GetDistance(Transform pos1, Transform pos2) {
        return Vector3.Distance(pos1.position, pos2.position);
    }

    private float calculateSlope(ClawJoint _Joint_m) {
                float deltaTheta = 0.01f;
        float distance1 = GetDistance(claw_end.transform, curr_target.transform);

        _Joint_m.rotateJoint(deltaTheta);

        float distance2 = GetDistance(curr_target.transform, claw_end.transform);
        _Joint_m.rotateJoint(-deltaTheta);

        

        return (distance2 - distance1) / deltaTheta;
    }

    private void doClawKinematics() {
        float distance = GetDistance(claw_end.transform, curr_target.transform);
        if (distance > threshhold) {
            //Debug.Log("WERE MOVING");
            is_moving = true;
            ClawJoint current = claw_base;
            while(current != null) {
                float slope = calculateSlope(current);
                current.rotateJoint(-slope * kinematic_speed);
                current = current.GetChild(); 
            }
        } else {
            is_moving = false;
        }
    }

    // Rotates the base object of the claw
    private void rotateClaw() {
        
        // Get target direction vector
        Vector3 targetDirection = curr_target.position - claw_pointer_base.position;

        // Zero out Y componenet
        Vector3 targetDir = new Vector3(targetDirection.x, 0f, targetDirection.z);
        
                // The step size is equal to speed times frame time.
        float singleStep = rotate_speed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(claw_pointer_base.transform.forward, targetDir, singleStep, 0.0f);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        claw_pointer_base.transform.rotation = Quaternion.LookRotation(newDirection);

    }

    /*
        End of private functions
    */



    // Start is called before the first frame update
    void Start()
    {   
        // On start check if coming from main menu or other parts of ship
        if(MainManager.Instance.scene_name_prev == "MainMenu") {
            curr_target = reset_position;
        } else {
            curr_target = player;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!PauseMenu.game_paused){
            rotateClaw();
            doClawKinematics();
        }
    }



}
