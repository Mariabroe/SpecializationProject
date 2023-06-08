using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainMover : MonoBehaviour
{
    void FixedUpdate()
    {
        if (transform.position.z <= -150)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 150);
        }
    }
}
