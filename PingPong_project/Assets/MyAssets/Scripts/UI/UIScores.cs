using TMPro;
using UnityEngine;

public class UIScores : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreTxtFirstPlayer;
    [SerializeField] private TextMeshProUGUI scoreTxtSecondPlayer;

    [SerializeField] private ScoreCollector scoreCollector;

    void Update()
    {
        scoreTxtFirstPlayer.text = scoreCollector.scoreFirstPlayer.ToString();
        scoreTxtSecondPlayer.text = scoreCollector.scoreSecondPlayer.ToString();
    }

}
