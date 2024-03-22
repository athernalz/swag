using Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake Instance;

    public CinemachineVirtualCamera cinemachineVirtualCamera;
    private float shakeDuration = 0f;
    private float initialAmplitude = 0f;
    private float initialFrequency = 0f;

    private void Awake()
    {
        Instance = this;
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera(float intensityDuration, float amplitude, float frequency)
    {
        var noise = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        noise.m_AmplitudeGain = amplitude;
        noise.m_FrequencyGain = frequency;

        initialAmplitude = amplitude;
        initialFrequency = frequency;
        shakeDuration = intensityDuration;
    }

    private void Update()
    {
        if (shakeDuration > 0)
        {
            shakeDuration -= Time.deltaTime;

            // Calculate the current amplitude and frequency based on the elapsed time
            float amplitudeRatio = shakeDuration <= 0f ? 0f : shakeDuration;
            float frequencyRatio = shakeDuration <= 0f ? 0f : shakeDuration;

            var noise = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            noise.m_AmplitudeGain = Mathf.Lerp(0f, initialAmplitude, amplitudeRatio);
            noise.m_FrequencyGain = Mathf.Lerp(0f, initialFrequency, frequencyRatio);

            if (shakeDuration <= 0f)
            {
                // Reset the noise gains when the shake duration is over
                noise.m_AmplitudeGain = 0f;
                noise.m_FrequencyGain = 0f;
            }
        }
    }
}
