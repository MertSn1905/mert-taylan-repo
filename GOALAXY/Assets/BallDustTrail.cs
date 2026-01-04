using UnityEngine;
using System.Collections;

public class BallDustTrail : MonoBehaviour
{
    public ParticleSystem dust;
    public float activeTime = 0.3f;
    public float offsetX = 0.3f;

    public void PlayDust(Transform kicker)
    {
        // Determine which side the kicker is on
        float side = kicker.position.x > transform.position.x ? 1f : -1f;

        // Place dust on the correct side of the ball
        dust.transform.localPosition = new Vector3(side * offsetX, 0f, 0f);

        StartCoroutine(DustRoutine());
    }

    private IEnumerator DustRoutine()
    {
        dust.Play();
        yield return new WaitForSeconds(activeTime);
        dust.Stop();
    }
}
