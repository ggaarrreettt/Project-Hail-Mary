using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct SmoveAbleObject {
    
    public bool onTable
    {
        get{return onTable;}
    }
    public bool inPlayerHands
    {
        get{return inPlayerHands;}
    }

    public Transform objTransform;

    private Transform table;
   
    //Constructor (not necessary, but helpful)
    public SmoveAbleObject(Transform table, Transform objTransform) {
        this.table = table;
        this.objTransform = objTransform;
    }

    public void snapToTable() {
        objTransform.position = new Vector3(objTransform.position.x,table.position.y + 0.125f ,objTransform.position.z);
    }
}
