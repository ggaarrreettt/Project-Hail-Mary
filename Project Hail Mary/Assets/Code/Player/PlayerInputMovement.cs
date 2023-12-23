using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputMovement : MonoBehaviour
{

    public PlayerClawMovement playerClawMovement;

    public PlayerBedMovement playerBedMovement;

    public PlayerLadderMovement playerLadderMovement;

    public float player_speed = 3.5f;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool grabbed_by_claw = playerClawMovement.grabbed_by_claw;
        bool in_bed = playerBedMovement.in_bed;
        bool on_ladder = playerLadderMovement.on_ladder;
        if(!grabbed_by_claw && !in_bed && !on_ladder) {
            inputMovement();
        }
    }

    // Makes the player move throughout the world
    private void inputMovement() {
        float x  = Input.GetAxis("Horizontal");
        float z  = Input.GetAxis("Vertical");
        


        // Update position
        Vector3 movement = new Vector3(x, 0, z);
        transform.Translate(movement * player_speed * Time.deltaTime);
    }
}
