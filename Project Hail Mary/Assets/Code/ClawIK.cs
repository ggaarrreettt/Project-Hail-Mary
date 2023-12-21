using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClawIK : MonoBehaviour
{

    public ClawJoint root;
    public ClawJoint end;

    public float rotate_speed = 5f;
    public int steps = 20;

    public Transform player;

    public Transform player_bed;

    static public Transform target;
    public float threshhold = 0.05f;
    float GetDistance(Transform pos1, Transform pos2) {
        return Vector3.Distance(pos1.position, pos2.position);
    }


    float CalculateSlope(ClawJoint _Joint_m) {

        float deltaTheta = 0.01f;
        float distance1 = GetDistance(end.transform, target.transform);

        _Joint_m.rotateJoint(deltaTheta);

        float distance2 = GetDistance(target.transform, end.transform);
        _Joint_m.rotateJoint(-deltaTheta);

        

        return (distance2 - distance1) / deltaTheta;
    }


    // Start is called before the first frame update
    void Start()
    {
        target = player;
    }

    // Update is called once per frame
    void Update()
    {



        // Check if need to put the player in bed
        

        // Do a number of steps
        for (int i = 0; i < steps; i++) {
            float distance = GetDistance(end.transform, target.transform);
            if (distance > threshhold) {
                ClawJoint current = root;
                while(current != null) {
                    float slope = CalculateSlope(current);
                    current.rotateJoint(-slope * rotate_speed);
                    current = current.GetChild(); 
                }
            }
        }
    }
}
