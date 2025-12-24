using UnityEngine;

public class BallKick : MonoBehaviour
{
    [SerializeField] private float kickForce = 8f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ball"))
            return;

        Rigidbody2D ballRb = collision.gameObject.GetComponent<Rigidbody2D>();
        if (ballRb == null) return;

        // Direction from player to ball
        Vector2 kickDirection =
            (ballRb.position - (Vector2)transform.position).normalized;

        // Reset current velocity for clean kick
        ballRb.linearVelocity = Vector2.zero;

        // Apply force
        ballRb.AddForce(kickDirection * kickForce, ForceMode2D.Impulse);
    }
}
