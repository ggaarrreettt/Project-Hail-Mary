using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLadderMovement : MonoBehaviour
{

    public PlayerClawMovement playerClawMovement;

    public PlayerBedMovement playerBedMovement;

    public PlayerInputMovement playerInputMovement;

    public bool near_ladder;

    public bool on_ladder;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        bool grabbed_by_claw = playerClawMovement.grabbed_by_claw;
        bool in_bed = playerBedMovement.in_bed;

        if(!in_bed && !grabbed_by_claw && near_ladder) {
            // Join/leave ladder
            joinLeaveLadder();

            if(on_ladder) {
                // Movement up/down ladder
                ladderMovement();
            }
        }
    }

    private void ladderMovement() {
        float y  = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(0, y, 0);
        transform.Translate(movement * playerInputMovement.player_speed * Time.deltaTime);
    }

    private void joinLeaveLadder() {
        if(Input.GetKeyDown(KeyCode.E)) {
            if(on_ladder) {
                on_ladder = false;
                rb.useGravity = true;
            } else {
                on_ladder = true;
                rb.useGravity = false;

            }
        }
        
    }

    void OnTriggerEnter(Collider other) {
        if(other.tag == "Ladder") {
            near_ladder = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.tag == "Ladder") {
            near_ladder = false;
        }
    }
}
