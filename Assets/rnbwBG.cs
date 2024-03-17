using UnityEngine;

public class RainbowBackground : MonoBehaviour
{
    public float colorChangeSpeed = 1f; // Speed at which colors change
    public float saturation = 0.5f; // Saturation for pastel colors
    public float value = 0.8f; // Value for pastel colors

    private Camera cam;
    private float hue = 0f; // Hue value for rainbow colors

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        // Increment hue over time
        hue += colorChangeSpeed * Time.deltaTime;
        hue %= 1f; // Ensure hue stays within [0,1] range

        // Set camera background color based on current hue value
        cam.backgroundColor = Color.HSVToRGB(hue, saturation, value);
    }
}
