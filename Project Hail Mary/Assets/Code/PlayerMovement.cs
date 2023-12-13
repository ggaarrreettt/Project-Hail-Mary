using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    Rigidbody rb;

    public float speed = 12f;


    void Start() {

        rb = GetComponent<Rigidbody>();
    }




    // Update is called once per frame
    void Update()
    {

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            rb.AddForce(transform.forward * z*5);
            rb.AddForce(transform.right * x*5);
            
            
            


    }
}
