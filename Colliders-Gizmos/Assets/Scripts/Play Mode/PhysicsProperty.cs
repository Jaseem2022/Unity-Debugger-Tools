using UnityEngine;

public class PhysicsProperty : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 previousVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        previousVelocity = rb.linearVelocity;
    }

    void Update()
    {
        Vector3 currentVelocity = rb.linearVelocity;

        DrawAccelerationOrDeceleration(currentVelocity);
        DrawForce(currentVelocity);

        // Update previous velocity only after both calculations
        previousVelocity = currentVelocity;
    }

    void DrawAccelerationOrDeceleration(Vector3 currentVelocity)
    {
        if (currentVelocity.magnitude >= previousVelocity.magnitude)
        {
            Debug.DrawLine(transform.position + Vector3.up * 0.1f,
                           transform.position + Vector3.up * 0.1f + currentVelocity,
                           Color.green,
                           1f);
        }
        else
        {
            Debug.DrawLine(transform.position + Vector3.up * 0.1f,
                           transform.position + Vector3.up * 0.1f + currentVelocity,
                           Color.red,
                           1.5f);
        }
    }

    void DrawForce(Vector3 currentVelocity)
    {
        Vector3 force = rb.mass * (currentVelocity - previousVelocity) / Time.deltaTime;
        Debug.DrawLine(transform.position + Vector3.up * 0.1f,
                       transform.position + Vector3.up * 0.1f + force,
                       Color.black);
    }
}
