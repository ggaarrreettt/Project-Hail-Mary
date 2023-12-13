using System.Collections;
using System.Collections.Generic;
using UnityEngine;




/*
Description:
    
    This is the movement/seeking class of the inteligent claw found in the Dormitory section of the Hail Mary.
    The claw seeks out the player




*/

public class ClawMovement : MonoBehaviour
{


    public Transform Arm1;
    public Transform Joint1;
    private float Joint1Rotation = 90f;
    public Transform Arm2;
    public Transform Joint2;
    public Transform BigFinger1;
    public Transform FingerJoint1;
    public Transform BigFinger2;
    public Transform FingerJoint2;
    public Transform BigFinger3;
    public Transform FingerJoint3;

    public float BigFingerMax = -90f;
    public float BigFingerMin = -145f;

    public float FingerJointMax = 190f;
    public float FingerJointMin = 100f;

    public float Joint1Max = 180f;
    public float Joint1Min = 45f;



    public Transform player;

    private float dir = 1;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.LeftShift)) {
            dir = -1;
        } else {
            dir = 1;
        }





        if (Input.GetKey(KeyCode.T)) {
            //graspClaw();
            rotateJoint1(dir);
        }
    }

    /*
        float mousX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mousX);
    */

    private void rotateJoint1(float direction) {
        Joint1Rotation -= direction * 20f * Time.deltaTime;
        Joint1Rotation = Mathf.Clamp(Joint1Rotation, Joint1Min, Joint1Max);

        Joint1.localRotation = Quaternion.Euler(0f, 0f, Joint1Rotation);
    }



    // Function that closes the claw's hands. A positive value closes, while a negative value opens
    private void graspClaw(float dir) {

        // Rotating the big fingers
        float angle = 20.0f * Time.deltaTime * -dir;
        angle = Mathf.Clamp(angle, BigFingerMin, BigFingerMax);
        Quaternion rotation = Quaternion.Euler(0,0,angle);

        //transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);


        BigFinger1.localRotation = rotation;
        BigFinger2.localRotation = rotation;
        BigFinger3.localRotation = rotation;

        // Roate little fingers
        angle = 50.0f * Time.deltaTime * -dir;
        angle = Mathf.Clamp(angle, FingerJointMin, FingerJointMax);
        rotation = Quaternion.Euler(0,0,angle);
        FingerJoint1.rotation *= rotation;
        FingerJoint2.rotation *= rotation;
        FingerJoint3.rotation *= rotation;



    }








}
