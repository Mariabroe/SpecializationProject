using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedOfObject : MonoBehaviour
{
    void FixedUpdate()
    {
        Vector3 newPosition = transform.position + new Vector3(0, 0, -SpeedManager.Instance.speed * Time.fixedDeltaTime);
        transform.position = newPosition;
    }
}
