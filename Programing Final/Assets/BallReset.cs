using System.Collections;
using UnityEngine;

public class BallReset : MonoBehaviour
{
    private Vector3 startPosition;
    private Rigidbody2D rb;

    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(ResetBallCoroutine());
    }

    IEnumerator ResetBallCoroutine()
    {
        yield return new WaitForSeconds(2f); // 2 saniye bekle

        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        transform.position = startPosition;
    }
}
