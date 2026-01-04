using System;
using UnityEngine;
using System.Collections;

public class GoalTrigger : MonoBehaviour
{
    public enum Team { Left, Right }

    [Header("Scoring")]
    [SerializeField] private Team scoringTeam;
    public static event Action<Team> OnGoalScored;

    [Header("Players")]
    [SerializeField] private PlayerMovement playerLeft;
    [SerializeField] private PlayerMovement playerRight;

    [Header("UI")]
    [SerializeField] private GameObject goalText;
    [SerializeField] private float showSeconds = 1f;

    [Header("Audio")]
    [SerializeField] private AudioSource goalAudio;

    private static bool goalLocked;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (goalLocked) return;
        if (!other.CompareTag("Ball")) return;

        goalLocked = true;

        OnGoalScored?.Invoke(scoringTeam);

        // GOAL yazýsý
        if (goalText != null)
            StartCoroutine(ShowGoal());

        // GOL SESÝ
        if (goalAudio != null)
            goalAudio.Play();

        // Oyuncularý respawnla
        if (playerLeft != null) playerLeft.Respawn();
        if (playerRight != null) playerRight.Respawn();

        StartCoroutine(UnlockNextFrame());
    }

    private IEnumerator ShowGoal()
    {
        goalText.SetActive(true);
        yield return new WaitForSeconds(showSeconds);
        goalText.SetActive(false);
    }

    private IEnumerator UnlockNextFrame()
    {
        yield return null;
        goalLocked = false;
    }
}






