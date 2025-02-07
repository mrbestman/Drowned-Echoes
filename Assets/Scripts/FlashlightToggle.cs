using UnityEngine;

public class FlashlightToggle : MonoBehaviour
{
    public Light flashlightLight;
    public AudioSource toggleSound;
    private bool isOn = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ToggleFlashlight();
        }
    }

    void ToggleFlashlight()
    {
        isOn = !isOn;
        flashlightLight.enabled = isOn;
        toggleSound.Play();
    }
}
