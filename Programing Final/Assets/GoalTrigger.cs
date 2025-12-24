using System;
using UnityEngine;

public class GoalTrigger : MonoBehaviour
{
    [SerializeField] private Team scoringTeam;

    // Event for score system & reset system
    public static event Action<Team> OnGoalScored;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Ball")) return;

        OnGoalScored?.Invoke(scoringTeam);
        Debug.Log($"GOAL! {scoringTeam} scored.");
    }

    public enum Team
    {
        Left,
        Right
    }
}