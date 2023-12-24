using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public static bool grabbed_by_claw = false;
    public static bool in_bed = false;
    public bool near_bed = false;

    public bool near_ladder = false;

    public bool on_ladder = false;

    public float player_speed = 2f;

    public Transform claw_reset;

    public Transform player_bed;

    public Transform ladder;

    private Collider player_collider;

    Rigidbody rb;

    public float speed = 12f;


    void Start() {

        rb = GetComponent<Rigidbody>();
        player_collider = GetComponent<Collider>();
    }

    private void player_input_movement() {
        float x  = Input.GetAxis("Horizontal");
        float z  = Input.GetAxis("Vertical");


        // Update position
        Vector3 movement = new Vector3(x, 0, z);
        transform.Translate(movement * player_speed * Time.deltaTime);
    }


    // Update is called once per frame
    void Update()
    {       
        // Only do player movement if not grabbed by claw, not in bed, not on ladder
        if(!grabbed_by_claw && !in_bed && !on_ladder) {
            player_input_movement();
        }

        if(near_ladder) {
            playerNearLadder();
        }

        // Do logic for the bed
        bedCheck();

    }

    private void playerNearLadder() {


        // Getting on and off the ladder
        if(Input.GetKeyDown(KeyCode.E)) {
            if(on_ladder) {
                getOffLadder();
            } else {
                getOnLadder();
            }
        }

        // Moving up and down the ladder
        if(on_ladder) {
            ladderMovement();
        }
    }

    private void ladderMovement() {

        float y  = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(0, y, 0);
        transform.Translate(movement * player_speed * Time.deltaTime);
    }

    private void getOnLadder() {

        on_ladder = true;
        rb.useGravity = false;
        transform.parent = ladder;
    }

    private void getOffLadder() {
        on_ladder = false;
        rb.useGravity = true;
        transform.parent = null;
    }

    // The player is near the bed, the claw is putting them into the bed now.
    private void putToBedByClaw() {
        
        // Take player out of the claw
        putPlayerOutOfClaw();

        // Reset the claw transform to avoid any weird re-collision with the player
        // #### THIS IS A TODO ###

        // Set the player into bed
        putPlayerInBed();

        // Tell claw to go elsewhere
        StartCoroutine(changeClawTarget(claw_reset, 0.5f));
        Debug.Log("Target going to claw reset");
    }

    private void bedCheck() {
        // Check if the player is near the bed
        if(near_bed) {
            // Player is within bed range


            if(grabbed_by_claw) {
                putToBedByClaw();
            } else {

                // Ability to get in and out of the bed
                if(Input.GetKeyDown(KeyCode.E)) {
                    if(in_bed) {
                        putPlayerOutOfBed();
                        StartCoroutine(changeClawTarget(transform, 2f));
                    } else {
                        putPlayerInBed();
                    }
                }
            }
        }
    }

    // This function changes the claw's target to provided 'new_target' after waiting
    // 'delay' seconds.
    private IEnumerator changeClawTarget(Transform new_target, float delay) {
        yield return new WaitForSeconds(delay);
        ClawIK.changeTarget(new_target);
        ClawBaseFollow.changeTarget(new_target);
    }


    // Makes the player a child of the claw end
    private void putPlayerInClaw(Transform claw) {
        transform.parent = claw;
        rb.useGravity = false;
        grabbed_by_claw = true;

        // Turn off the player's collider
        //player_collider.enabled = false;
        rb.isKinematic = true;

    }

    private void putPlayerOutOfClaw() {
        transform.parent = null;
        rb.useGravity = true;
        grabbed_by_claw = false;

        // Turn back on the player's collider
        player_collider.enabled = true;
        rb.isKinematic = false;

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
            Debug.Log("Claw Enter");
            
            // Have player be grasped by claw
            putPlayerInClaw(other.GetComponent<Transform>());

            // Change the target of the claw
            StartCoroutine(changeClawTarget(player_bed, 0f));
        }

        // Check if bed
        if(other.tag == "PlayerBed") {
            near_bed = true;
        }

        // Check if ladder
        if(other.tag == "Ladder") {
            Debug.Log("NEAR THE LADDER");
            near_ladder = true;

        }
    }

    void OnTriggerExit(Collider other) {
        
        // Check if claw
        if(other.tag == "Claw") {
            grabbed_by_claw = false;
            transform.parent = null;
            Debug.Log("Claw Leave");

        }

        // Check if bed
        if(other.tag == "PlayerBed") {
            near_bed = false;
        }

        if(other.tag == "Ladder") {
            Debug.Log("NO LONGER NEAR LADDER");
            near_ladder = false;
        }

    }
}
