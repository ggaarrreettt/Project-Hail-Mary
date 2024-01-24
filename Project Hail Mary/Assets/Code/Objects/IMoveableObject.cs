using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ImoveAbleObject {
    
    //public bool onTable{get;}
    //public bool inPlayerHands{get;}
    



    public void snapToTable(Transform labEquipment, Transform table) {
        labEquipment.position = new Vector3(labEquipment.position.x,table.position.y + 0.125f ,labEquipment.position.z);
    }

    // Implement putting in players hands
}
