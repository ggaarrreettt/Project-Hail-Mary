using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerLabItems : MonoBehaviour
{

    Ray ray;

    private Transform holdingObj;

    private bool holdingObject = false;

    public float scale = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) {
            if(!holdingObject) {
                ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
                if(Physics.Raycast(ray, out RaycastHit hit, maxDistance:5))
                if(hit.transform.tag == "LabItem") {
                    holdingObj = hit.transform;
                    holdingObj.GetComponent<Rigidbody>().useGravity = false;
                    holdingObj.GetComponent<Rigidbody>().isKinematic = true;
                    holdingObj.SetParent(transform);
                    holdingObject = !holdingObject;
                }
                
            } else {
                holdingObject = !holdingObject;
                holdingObj.GetComponent<Rigidbody>().useGravity = true;
                holdingObj.GetComponent<Rigidbody>().isKinematic = false;
                holdingObj.SetParent(null);
            }
        }


        // Move obj input
        if(holdingObj) {
            Vector3 pos = holdingObj.position;
            pos.y += Input.mouseScrollDelta.y * scale;
            holdingObj.position = pos;
        }
    }



    void OnTriggerEnter(Collider other) {
        if(other.tag == "LabItem") {

        }
    }

}
