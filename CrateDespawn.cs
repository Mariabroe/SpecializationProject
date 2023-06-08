using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateDespawn : MonoBehaviour
{
    public ComboManager comboManager;
    public SoundManager soundManager;
    public AudioClip crateMissedSound;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "RedBox" || other.gameObject.tag == "BlueBox")
        {
            comboManager.ResetCombo();
            SpeedManager.Instance.ChangeSpeed(-0.5f); // Subtract 0.5 from the speed
            soundManager.PlaySound(crateMissedSound);
            Destroy(other.gameObject);
        }
    }
}