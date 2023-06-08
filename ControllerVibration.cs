using UnityEngine;
using UnityEngine.XR;

public class ControllerVibration : MonoBehaviour
{
    public XRNode inputSource; // Specify the XRNode for the respective controller (LeftHand or RightHand)
    private InputDevice targetDevice;
    private ComboManager comboManager;
    private SoundManager soundManager;
    public AudioClip crateDestroySound;
    public string interactableTag; // Assign the tag name in the inspector

    private void Start()
    {
        targetDevice = InputDevices.GetDeviceAtXRNode(inputSource);
        comboManager = FindObjectOfType<ComboManager>();
        soundManager = FindObjectOfType<SoundManager>();
    }

    public void TriggerHapticFeedback(float duration, float amplitude)
    {
        if (targetDevice.isValid)
        {
            HapticCapabilities capabilities;
            if (targetDevice.TryGetHapticCapabilities(out capabilities))
            {
                if (capabilities.supportsImpulse)
                {
                    uint channel = 0; // Channel 0 represents the default channel for haptic feedback
                    targetDevice.SendHapticImpulse(channel, amplitude, duration);
                }
            }
        }
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == interactableTag) // Use interactableTag
        {
            comboManager.IncrementCombo();
            soundManager.PlaySound(crateDestroySound);
            SpeedManager.Instance.ChangeSpeed(0.1f);
            TriggerHapticFeedback(0.1f, 1.0f); // Trigger Crate hit vibration on the controller
            Destroy(other.gameObject);
        }
    }
}