using UnityEngine;

public class SineWaveBounce : MonoBehaviour
{
    public float amplitude = 1f;      // Height of the wave
    public float frequency = 6f;       // Speed of wave oscillation
    public float phaseOffset = 0f;     // Used to offset each letter
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        float newY = Mathf.Sin(Time.time * frequency + phaseOffset) * amplitude;
        transform.localPosition = new Vector3(startPos.x, startPos.y + newY, startPos.z);
    }
}
