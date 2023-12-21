using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public static bool grabbed_by_claw = false;
    public static bool in_bed = false;
    public bool near_bed = false;

    public Transform player_bed;

    Rigidbody rb;

    public float speed = 12f;


    void Start() {

        rb = GetComponent<Rigidbody>();
    }




    // Update is called once per frame
    void Update()
    {       
        // Only do player movement if not grabbed by claw
        if(!grabbed_by_claw && !in_bed) {
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            rb.AddForce(transform.forward * z*5);
            rb.AddForce(transform.right * x*5);
        }

        // Check input for getting out of bed
        if(near_bed) {
            // Ability to hop in bed, or claw to put player in bed
            if(grabbed_by_claw) {
                // Throw in bed
                putPlayerInBed();
                grabbed_by_claw = false;
            } else {

                // Ability to get in and out of the bed
                if(Input.GetKeyDown(KeyCode.E)) {
                    if(in_bed) {
                        putPlayerOutOfBed();
                    } else {
                        putPlayerInBed();
                    }
                }
            }
        }
        

    }



    private void putPlayerInBed() {
        in_bed = true;
        rb.velocity = Vector3.zero;
        rb.useGravity = false;
        transform.position = player_bed.position + new Vector3(0,0.5f,0);
        transform.rotation = Quaternion.Euler(-90, 0 ,0);
        
    }

    private void putPlayerOutOfBed() {
        in_bed = false;
        rb.useGravity = true;
        transform.position = player_bed.position + new Vector3(2.25f, 1, 0);
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    void OnTriggerEnter(Collider other) {
        
        // Check if claw is touching
        if(other.tag == "Claw") {
            rb.useGravity = false;
            grabbed_by_claw = true;
            transform.parent = other.GetComponent<Transform>();
            ClawIK.target = player_bed;
            ClawBaseFollow.target = player_bed;
        }

        // Check if bed
        if(other.tag == "PlayerBed") {
            near_bed = true;
        }
    }

    void OnTriggerExit(Collider other) {
        
        // Check if claw
        if(other.tag == "Claw") {
            grabbed_by_claw = false;
            transform.parent = null;
        }

        // Check if bed
        if(other.tag == "PlayerBed") {
            near_bed = false;
        }

    }
}
