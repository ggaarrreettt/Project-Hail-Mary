using UnityEngine;

public class BeGripped : MonoBehaviour
{
    public Transform hand;
    Rigidbody rb;

    private bool finger1;
    private bool finger2;
    private bool finger3;

    int tCount;

    void Start()
    {
        //Debug.Log("Started Gripper");
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.transform.name);
        
        // Detect if finger has touched
        if(other.transform.name == "FingerTip1") {
            finger1 = true;
        } else if (other.transform.name == "FingerTip2") {
            finger2 = true;
        } else if (other.transform.name == "FingerTip3") {
            finger3 = true;
        }

        // Detect if all fingers are touching
        if (finger1 && finger2 && finger3) {
            hand = other.transform.parent.transform.parent.transform.parent.transform.parent;
            transform.parent = hand;
            rb.useGravity = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Detect if finger has left
        if(other.transform.name == "FingerTip1") {
            finger1 = false;
        } else if (other.transform.name == "FingerTip2") {
            finger2 = false;
        } else if (other.transform.name == "FingerTip3") {
            finger3 = false;
        }

        // Detect if gripped
        if (!(finger1 && finger2 && finger3)) {
            transform.parent = null;
            rb.useGravity = true;
        }
        //Debug.Log("UN-COLLIDE");
    }
}