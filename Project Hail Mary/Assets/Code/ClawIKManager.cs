using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClawIKManager : MonoBehaviour
{

    // Holds base Joint_m
    public Joint_m m_root;

    // End Joint_m
    public Joint_m m_end;

    public float m_rate = 5.0f;
    public GameObject m_target;

    public float m_threshhold = 0.05f;

    public float m_min_distance = 5f;

    public int m_steps = 20;


    float CalculateSlope(Joint_m _Joint_m) {

        float deltaTheta = 0.01f;
        float distance1 = GetDistance(m_end.transform.position, m_target.transform.position);

        _Joint_m.m_Rotate(deltaTheta);

        float distance2 = GetDistance(m_end.transform.position, m_target.transform.position);
        _Joint_m.m_Rotate(-deltaTheta);

        

        return (distance2 - distance1) / deltaTheta;
    }

    float GetDistance(Vector3 _point1, Vector3 _point2) {
        return Vector3.Distance(_point1, _point2);
    }

    
    // Update is called once per frame
    void Update()
    {   
        for(int i = 0; i < m_steps; i++) {
            float distance = GetDistance(m_end.transform.position, m_target.transform.position);
            float distance_to_base = GetDistance(m_root.transform.position, m_target.transform.position);
            if(distance_to_base <= m_min_distance && distance > m_threshhold) {
                Joint_m current = m_root;
                while(current != null) {
                    float slope = CalculateSlope(current);
                    current.m_Rotate(-slope * m_rate * Time.deltaTime);
                    current = current.GetChild_m(); 
                }
            }
        }   
    }
}
