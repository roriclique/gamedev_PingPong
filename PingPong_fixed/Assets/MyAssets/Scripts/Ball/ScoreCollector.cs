using UnityEngine;

public class ScoreCollector : MonoBehaviour
{
    [HideInInspector] public int scoreFirstPlayer;
    [HideInInspector] public int scoreSecondPlayer;

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
