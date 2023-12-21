using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClawBaseFollow : MonoBehaviour
{

    
    public Vector3 rot = new Vector3(1f,1f,1f);

    public Transform player;

    public static Transform target;

    public float rotate_speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        target = player;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMovement.grabbed_by_claw == false) {
            gotothe();
        }
    }


    private void followPlayer() {
        Vector3 target_line = (target.position - transform.position);
        
        
        float singleStep = rotate_speed * Time.deltaTime;

        //Vector3 newDirection = Vector3.RotateTowards(transform.right, target_line, singleStep, 0.0f);
        Vector3 newDirection = Vector3.RotateTowards(transform.right, target_line, singleStep, 0.0f);


        transform.rotation = Quaternion.LookRotation(newDirection);

    }

    public void gotothe() {
        // Determine which direction to rotate towards

        Vector3 targetDirection = target.position - transform.position;

        // Zero-out the Y componenet
        Vector3 targetDir = new Vector3(targetDirection.x, 0f, targetDirection.z);

        // The step size is equal to speed times frame time.
        float singleStep = rotate_speed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDir, singleStep, 0.0f);

        // Draw a ray pointing at our target in
        //Debug.DrawRay(transform.position, newDirection, Color.red);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
