using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LabObject : MonoBehaviour, ImoveAbleObject
{
    
    public bool onTable = true;

    public bool inPlayerHand = false;

    // Only true when the item is within placing distance of the lab table, and in the player's hand
    public bool snapable = false;


    public bool inPlayerHands => throw new System.NotImplementedException();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void OnTriggerEnter(Collider other) {
        if(other.tag == "Table") {
            if(inPlayerHand) {
                snapable = true;
            }
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.tag == "Table") {
            snapable = false;
        }
    }


}
