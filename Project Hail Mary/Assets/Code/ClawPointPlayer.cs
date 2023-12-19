using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawPointPlayer : MonoBehaviour
{

    public Transform player;
    private Vector3 zero_out = new Vector3(1,0,1);

    private Vector3 dir(Transform other) {
        // Gets a line to other but zeroed out in y dir
        Vector3 line_to = Vector3.Scale((other.position - transform.position), zero_out);
        return line_to;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update1()
    {


        Vector3 direction = dir(player);
        Vector3 pos = Vector3.Scale(player.position, zero_out);

        float angle = Vector3.Angle(direction, pos);


        transform.Rotate(transform.up * angle);
    }
}
