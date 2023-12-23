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



    public static void changeTarget(Transform targ) {
        target = targ;
    }

    // Start is called before the first frame update
    void Start()
    {
        target = player;
    }

    // Update is called once per frame
    void Update()
    { 
        followTarget();        
    }

    // Follows the 'target' transform
    public void followTarget() {
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
