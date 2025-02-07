using UnityEngine;

public class FlashlightSway : MonoBehaviour
{
    public float swayAmount = 5f; // Max angle of sway
    public float swaySpeed = 2f;  // Speed of sway

    private float initialZRotation;

    void Start()
    {
        initialZRotation = transform.localEulerAngles.z;
    }

    void Update()
    {
        float sway = Mathf.Sin(Time.time * swaySpeed) * swayAmount;
        transform.localRotation = Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y, initialZRotation + sway);
    }
}
