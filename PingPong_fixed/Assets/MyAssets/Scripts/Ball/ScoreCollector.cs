using UnityEngine;

public class ScoreCollector : MonoBehaviour
{
    public Ball ball;

    [HideInInspector] public int scoreFirstPlayer;
    [HideInInspector] public int scoreSecondPlayer;

    public void StartScores()
    {
        scoreFirstPlayer = 0;
        scoreSecondPlayer = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Score1Player"))
        {
            scoreFirstPlayer++;
        }

        if (collision.gameObject.CompareTag("Score2Player"))
        {
            scoreSecondPlayer++;
        }
    }
}
