using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerClawMovement : MonoBehaviour
{

    public ClawController clawController;

    public bool grabbed_by_claw = false;

    private Rigidbody rb;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*
        List of private/public functions to affect the player's movement
        in relation to the claw
    */
    private void beGrabbed() {
        grabbed_by_claw = true;
        rb.useGravity = false;
        rb.isKinematic = true;
        transform.parent = clawController.claw_end;
        clawController.targetBed(0f);
    }

    public void beUnGrabbed() {
        grabbed_by_claw = false;
        rb.useGravity = true;
        rb.isKinematic = false;
        transform.parent = null;
    }

    /*
        End of private functions
    */


    void OnTriggerEnter(Collider other) {
        if(other.tag == "Claw") {
            beGrabbed();
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.tag == "Claw") {
            beUnGrabbed();
        }
    }



}
