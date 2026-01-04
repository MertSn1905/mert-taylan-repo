using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 8f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Topun h�z�n� s�n�rla (pong gibi u�mas�n)
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }
}