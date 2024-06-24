using UnityEngine;

public class Modes : MonoBehaviour
{
    [SerializeField] public FirstPlayerController player1Controller;
    [SerializeField] public SecondPlayerController player2Controller;
    [SerializeField] public BotController botController;

    void Start()
    {
        player1Controller = GetComponentInChildren<FirstPlayerController>();
        player2Controller = GetComponentInChildren<SecondPlayerController>();
        botController = GetComponentInChildren<BotController>();
    }

    public void SingleMode()
    {
        player1Controller.enabled = true;
        botController.enabled = true;
    }

    public void MultiMode()
    {
        player1Controller.enabled = true;
        player2Controller.enabled = true;
    }
}
