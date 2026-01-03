using System.Collections;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI scoreText;

    [Header("Ball Reset")]
    [SerializeField] private Rigidbody2D ballRigidbody;
    [SerializeField] private Transform ballSpawnPoint;
    [SerializeField] private float resetDelaySeconds = 1.5f;

    private int leftScore = 0;
    private int rightScore = 0;

    private Coroutine resetCoroutine;

    private void OnEnable()
    {
        GoalTrigger.OnGoalScored += HandleGoalScored;
    }

    private void OnDisable()
    {
        GoalTrigger.OnGoalScored -= HandleGoalScored;
    }

    private void Start()
    {
        UpdateScoreText();
    }

    private void HandleGoalScored(GoalTrigger.Team scoringTeam)
    {
        if (scoringTeam == GoalTrigger.Team.Left)
        {
            leftScore++;
        }
        else
        {
            rightScore++;
        }

        UpdateScoreText();

        if (resetCoroutine != null)
        {
            StopCoroutine(resetCoroutine);
        }

        resetCoroutine = StartCoroutine(ResetBallCoroutine());
    }

    private void UpdateScoreText()
    {
        if (scoreText == null) return;

        scoreText.text = $"{leftScore} : {rightScore}";
    }

    private IEnumerator ResetBallCoroutine()
    {
        yield return new WaitForSeconds(resetDelaySeconds);

        if (ballRigidbody == null || ballSpawnPoint == null)
            yield break;

        // Stop physics
        ballRigidbody.linearVelocity = Vector2.zero;
        ballRigidbody.angularVelocity = 0f;

        // Move ball to center
        ballRigidbody.position = ballSpawnPoint.position;

        // Small random kickoff force
       //  Vector2 randomDir = Random.insideUnitCircle.normalized;
      //   ballRigidbody.AddForce(randomDir * 150f, ForceMode2D.Impulse);
    }
}

        