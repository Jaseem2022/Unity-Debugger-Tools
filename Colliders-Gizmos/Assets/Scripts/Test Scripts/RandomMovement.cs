using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RandomMovement : MonoBehaviour
{
    public float amplitudeX = 5f;
    public float amplitudeY = 5f;
    public float frequencyX = 1.5f;
    public float frequencyY = 1.5f;
    public float forceMultiplier = 10f;

    private Rigidbody rb;
    private Vector3 startPos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
    }

    void FixedUpdate()
    {
        // Target position based on sine/cosine
        float targetX = Mathf.Sin(Time.time * frequencyX) * amplitudeX;
        float targetY = Mathf.Cos(Time.time * frequencyY) * amplitudeY;
        Vector3 targetPos = startPos + new Vector3(targetX, targetY, 0f);

        // Calculate desired velocity to reach target
        Vector3 desiredVelocity = (targetPos - rb.position) / Time.fixedDeltaTime;

        // Apply force to reach desired velocity
        Vector3 force = (desiredVelocity - rb.linearVelocity) * rb.mass;
        rb.AddForce(force);

    }
}
