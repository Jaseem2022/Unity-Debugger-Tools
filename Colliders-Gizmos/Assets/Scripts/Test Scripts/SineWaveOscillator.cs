using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SineWaveOscillator : MonoBehaviour
{
    public float amplitude = 3f;    // Maximum distance from center
    public float frequency = 1f;    // Oscillations per second
    public float forceMultiplier = 10f; // Strength of the force applied

    private Rigidbody rb;
    private float timeCounter = 0f;
    private float lastX = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;  // optional
    }

    void FixedUpdate()
    {
        timeCounter += Time.fixedDeltaTime;

        // Desired X position based on sine
        float desiredX = Mathf.Sin(timeCounter * frequency * 2f * Mathf.PI) * amplitude;

        // Calculate velocity needed to reach desiredX this frame
        float velocityX = (desiredX - lastX) / Time.fixedDeltaTime;

        // Apply force to match desired velocity along X-axis
        Vector3 velocityChange = new Vector3(velocityX - rb.linearVelocity.x, 0f, 0f);
        rb.AddForce(velocityChange * forceMultiplier, ForceMode.Force);

        lastX = desiredX;
    }
}
