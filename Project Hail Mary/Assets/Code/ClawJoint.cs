using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawJoint : MonoBehaviour
{


    public ClawJoint child_joint;
    public bool do_thing = false;


    public ClawJoint GetChild(){
        return child_joint;
    }
    
    public void rotateJoint(float degree) {
        //degree *= Time.deltaTime
        Quaternion rotation = Quaternion.Euler(0, 0, degree);
        transform.localRotation *= rotation;

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (do_thing) {
            do_thing = false;
            StartCoroutine(dog(45f));
            
        }
    }

    public IEnumerator dog(float degree) {
        yield return new WaitForSeconds(1f);
        rotateJoint(degree);
    }
}
