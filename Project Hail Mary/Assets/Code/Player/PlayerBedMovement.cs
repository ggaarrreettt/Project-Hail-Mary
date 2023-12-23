using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBedMovement : MonoBehaviour
{


    public bool near_bed = false;

    public bool in_bed = false;

    public PlayerClawMovement playerClawMovement;

    public ClawController clawController;

    public Transform player_bed;

    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        putInBed();
    }

    // Update is called once per frame
    void Update()
    {
        if(near_bed) {
            nearBedLogic();
        }
    }


    /*
        List of private functions
    */

    private void nearBedLogic() {
        if(playerClawMovement.grabbed_by_claw) {
            // Player is grabbed by claw, put the player
            // into the bed
            clawToBed();
        } else {
            // Player is not grabbed by the claw, give them
            // the option to get into the bed
            playerToBed();
        }
    }

    // Function that puts the player in bed
    private void putInBed() {
        in_bed = true;
        rb.useGravity = false;
        transform.position = player_bed.position + new Vector3(0,0.5f,0);
        transform.rotation = Quaternion.Euler(-90, 0 ,0);
        clawController.targetReset(0f);

    }

    // Function that puts the player out of bed
    private void putOutOfBed() {
        in_bed = false;
        rb.useGravity = true;
        transform.position = player_bed.position + new Vector3(2.25f, 1, 0);
        transform.rotation = Quaternion.Euler(Vector3.zero);
        clawController.targetPlayer(2f);
    }

    // Function for when the claw puts the player to bed
    private void clawToBed() {
        playerClawMovement.beUnGrabbed();
        putInBed();
    }

    // Function for when the player puts themselves into/out of bed
    private void playerToBed() {
        if(Input.GetKeyDown(KeyCode.E)) {
            if(in_bed) {
                putOutOfBed();
            } else {
                putInBed();
            }
        }
    }


    /*
    */




    void OnTriggerEnter(Collider other) {
        if(other.tag == "PlayerBed") {
            near_bed = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.tag == "PlayerBed") {
            near_bed = false;
        }
    }



}
