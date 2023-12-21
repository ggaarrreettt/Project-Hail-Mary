using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RobotArmIK : MonoBehaviour
{
    public Transform target;  // The target object to reach
    public Transform[] joints; // The joints of the robot arm

    void Update()
    {
        MoveToTarget();
    }

    void MoveToTarget()
    {
        // Calculate the IK for the end effector
        Vector3 targetPosition = target.position;
        Vector3[] jointPositions = new Vector3[joints.Length];

        // Set the last joint position to be the target position
        jointPositions[joints.Length - 1] = targetPosition;

        // Iterate through the joints in reverse to calculate positions
        for (int i = joints.Length - 2; i >= 0; i--)
        {
            Vector3 toTarget = jointPositions[i + 1] - joints[i].position;
            jointPositions[i] = joints[i + 1].position - toTarget.normalized * GetSegmentLength(i);
        }

        // Apply the calculated positions to the joints
        for (int i = 0; i < joints.Length - 1; i++)
        {
            joints[i + 1].position = jointPositions[i + 1];
        }

        // Rotate joints to look at the target
        for (int i = 0; i < joints.Length - 1; i++)
        {
            Vector3 toTargetDir = jointPositions[i + 1] - joints[i].position;
            joints[i].rotation = Quaternion.LookRotation(toTargetDir, Vector3.up);
        }
    }

    float GetSegmentLength(int jointIndex)
    {
        // Adjust this function based on the length of your robot arm segments
        // You may want to store segment lengths in an array or use other methods
        return Vector3.Distance(joints[jointIndex].position, joints[jointIndex + 1].position);
    }
}
