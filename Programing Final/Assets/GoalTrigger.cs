using System;
using UnityEngine;
using System.Collections;

public class GoalTrigger : MonoBehaviour
{
    public enum Team
    {
        Left,
        Right
    }

    [Header("Scoring")]
    [SerializeField] private Team scoringTeam;

    [Header("Players to Respawn")]
    [SerializeField] private PlayerMovement playerLeft;
    [SerializeField] private PlayerMovement playerRight;

    [Header("UI (GOAL Text)")]
    [SerializeField] private GameObject goalText;         // drag Canvas/GoalText here
    [SerializeField] private float goalTextDuration = 1f;  // seconds

    public static event Action<Team> OnGoalScored;

    private static bool goalLocked;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (goalLocked) return;
        if (!other.CompareTag("Ball")) return;

        goalLocked = true;

        // ---------- DEBUG (TEST) ----------
        Debug.Log("GOAL TRIGGERED on: " + gameObject.name);
        Debug.Log("goalText assigned? " + (goalText != null));
        if (goalText != null)
        {
            Debug.Log("goalText name: " + goalText.name);
            Debug.Log("goalText activeSelf BEFORE: " + goalText.activeSelf);
        }
        // -------------------------------

        // Score event
        OnGoalScored?.Invoke(scoringTeam);

        // Show GOAL text
        if (goalText != null)
        {
            StopAllCoroutines(); // prevents overlapping on same trigger
            StartCoroutine(ShowGoalText());
        }

        // Respawn players
        if (playerLeft != null) playerLeft.Respawn();
        if (playerRight != null) playerRight.Respawn();

        StartCoroutine(UnlockNextFrame());
    }

    private IEnumerator ShowGoalText()
    {
        // ---------- DEBUG (TEST) ----------
        Debug.Log("ShowGoalText running on: " + gameObject.name);
        // -------------------------------

        goalText.SetActive(true);

        // ---------- DEBUG (TEST) ----------
        Debug.Log("goalText activeSelf AFTER SET TRUE: " + goalText.activeSelf);
        // -------------------------------

        yield return new WaitForSeconds(goalTextDuration);

        goalText.SetActive(false);

        // ---------- DEBUG (TEST) ----------
        Debug.Log("goalText activeSelf AFTER SET FALSE: " + goalText.activeSelf);
        // -------------------------------
    }

    private IEnumerator UnlockNextFrame()
    {
        yield return null; // 1 frame
        goalLocked = false;
    }
}





