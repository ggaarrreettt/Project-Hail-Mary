using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joint_m : MonoBehaviour
{
    public Joint_m m_child;
    
    public Joint_m GetChild_m() {
        return m_child;
    }

    private float joint_rot = 0f;

    public float rotate_rate = 20f;

    public bool do_thing = false;

    public void m_Rotate(float _angle) {
        // Rotate on the transform.forward local axis


        /*
                Joint1Rotation -= direction * 20f * Time.deltaTime;
        Joint1Rotation = Mathf.Clamp(Joint1Rotation, Joint1Min, Joint1Max);

        Joint1.localRotation = Quaternion.Euler(0f, 0f, Joint1Rotation);
        */

        joint_rot -= _angle * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(0f, 0f, joint_rot);


        //transform.Rotate(transform.forward * _angle);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator dog(float degree) {
        yield return new WaitForSeconds(5f);
        m_Rotate(degree);
    }
}
