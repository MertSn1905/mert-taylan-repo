using UnityEngine;

public class BallKick : MonoBehaviour
{
    [SerializeField] private float kickForce = 8f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Make sure we only react to the ball
        if (!collision.gameObject.CompareTag("Ball"))
            return;

        Rigidbody2D ballRb = collision.gameObject.GetComponent<Rigidbody2D>();
        if (ballRb == null)
            return;

        // Calculate kick direction (from player to ball)
        Vector2 kickDirection =
            (ballRb.position - (Vector2)transform.position).normalized;

        // Reset current velocity for a clean kick
        ballRb.linearVelocity = Vector2.zero;

        // Apply kick force
        ballRb.AddForce(kickDirection * kickForce, ForceMode2D.Impulse);

        // 🔥 Trigger dust trail (left / right based on player)
        BallDustTrail dustTrail = collision.gameObject.GetComponent<BallDustTrail>();
        if (dustTrail != null)
        {
            dustTrail.PlayDust(transform);
        }

        // 🔊 Play kick sound (safe & reliable)
        AudioSource audioSource = collision.gameObject.GetComponent<AudioSource>();
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.PlayOneShot(audioSource.clip);
        }
    }
}
