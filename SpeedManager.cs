using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    public static SpeedManager Instance { get; private set; }

    private float minSpeed = 3.0f;  // 
    public float speed = 3.0f;      // Initial Speed

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void ChangeSpeed(float speedChange)
    {
        if (speed >= 3.0f)
        {
            speed += speedChange;
        }
        else
        {
            speed = minSpeed;
        }
    }
}