using TMPro;
using UnityEngine;

public class UIScores : MonoBehaviour
{
    public TextMeshProUGUI scoreTxtFirstPlayer;
    public TextMeshProUGUI scoreTxtSecondPlayer;

    [SerializeField] private ScoreCollector scoreCollector;

    void Update()
    {
        scoreTxtFirstPlayer.text = scoreCollector.scoreFirstPlayer.ToString();
        scoreTxtSecondPlayer.text = scoreCollector.scoreSecondPlayer.ToString();
    }

}
