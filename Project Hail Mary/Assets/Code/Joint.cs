using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joint_m : MonoBehaviour
{
    public Joint_m m_child;
    
    public Joint_m GetChild_m() {
        return m_child;
    }

    public void Rotate(float _angle) {
        transform.Rotate(Vector3.forward * _angle);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
