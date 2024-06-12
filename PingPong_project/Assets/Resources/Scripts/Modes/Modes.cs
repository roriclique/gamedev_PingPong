using UnityEngine;

public class Mods : MonoBehaviour
{
    [SerializeField] private FirstPlayerController player1Controller;
    [SerializeField] private SecondPlayerController player2Controller;
    [SerializeField] private BotController botController;

    private void Start()
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
