using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class LinearMovement : MonoBehaviour
{
    public float speed = 5f;         // How fast it moves
    public float maxDistance = 3f;   // Max distance from start position

    private Rigidbody rb;
    private Vector3 startPos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;      // optional, prevents falling
        startPos = transform.position;
    }

    void FixedUpdate()
    {
        // Calculate target position using simple linear ping-pong
        float targetY = startPos.y + Mathf.PingPong(Time.time * speed, maxDistance * 2) - maxDistance;

        // Calculate required velocity to reach target
        float velocityY = (targetY - transform.position.y) / Time.fixedDeltaTime;

        // Apply force along Y
        float forceMultiplier = rb.mass;  // simple proportional force
        rb.AddForce(new Vector3(0f, velocityY * forceMultiplier, 0f), ForceMode.Force);
    }
}
