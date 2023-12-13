using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Vector3 translationRate;
    public Vector3 rotationRate;
    public string key;

    void Update()
    {        
        // Determine which key is pressed
        if (Input.GetKey(KeyCode.T) || key == "t") {
            // t is pressed, sphere #2 should turn
            turnSphereTwo();
        } else if (Input.GetKey(KeyCode.R) || key == "r") {
            upSphereTwo();
        } else if (Input.GetKey(KeyCode.U) || key == "u") { 
            rotateArmThree();
        } else if (Input.GetKey(KeyCode.H) || key == "h") {
            graspClaw();
        } else if (Input.GetKey(KeyCode.E) || key == "e") {
            rotateSphereFour();
        } // Else: no useful key has been pressed
    }

    // Big fingers and small fingers move at different rates, key: h
    void graspClaw() {



        if(transform.name == "BigFinger") {
            float angle = 20.0f * Time.deltaTime * (Input.GetKey(KeyCode.LeftShift) ? -1 : 1);
            Quaternion rotation = Quaternion.Euler(0,0,angle);
            transform.rotation *= rotation;

        }

        if(transform.name == "LittleFinger") {
            float angle = 50.0f * Time.deltaTime * (Input.GetKey(KeyCode.LeftShift) ? -1 : 1);
            Quaternion rotation = Quaternion.Euler(0,0,angle);
            transform.rotation *= rotation;
        }
    }

    // Move hand arm, key: E
    void rotateSphereFour() {
        if (transform.name == "Sphere4") {
            float angle = 10.0f * Time.deltaTime * (Input.GetKey(KeyCode.LeftShift) ? -1 : 1);
            Quaternion rotation = Quaternion.Euler(0,0,angle);
            transform.rotation *= rotation;

        }
    }

    // Turn the entire crane, key: T
    void turnSphereTwo() {
        if (transform.name == "Sphere2") {
            float angle = 30.0f * Time.deltaTime * (Input.GetKey(KeyCode.LeftShift) ? -1 : 1);
            Quaternion rotation = Quaternion.Euler(0, angle, 0);
            transform.rotation *= rotation;
        }
    }

    // Move the entire crane up, key: R
    void upSphereTwo() {
        if (transform.name == "Sphere2") {
            transform.Translate(0f, 0.5f * translationRate[1] * Time.deltaTime * (Input.GetKey(KeyCode.LeftShift) ? -1 : 1), 0f);
        }
    }

    // Rotate the first big arm, keeping the second arm parallel key: u
    void rotateArmThree() {
        // When rotating this arm, need to rotate the next sphere so that everything is parallel
        if (transform.name == "Arm3") {
            float angle = 20.0f * Time.deltaTime * (Input.GetKey(KeyCode.LeftShift) ? -1 : 1);
            Quaternion rotation = Quaternion.Euler(0,0,angle);
            transform.rotation *= rotation;
        }

        // Keep children parallel
        if (transform.name == "Sphere4") {
            float angle = 20.0f * Time.deltaTime * -1 * (Input.GetKey(KeyCode.LeftShift) ? -1 : 1);
            Quaternion rotation = Quaternion.Euler(0,0,angle);
            transform.rotation *= rotation;

        }
    }
}
