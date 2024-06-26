using UnityEngine;

public class Modes : Controller
{
    public void BotMode()
    {
        player1Controller.gameObject.SetActive(false);
        player2Controller.gameObject.SetActive(false);

        bot1Controller.gameObject.SetActive(true);
        bot2Controller.gameObject.SetActive(true);
    }

    public void MultiMode()
    {
        player1Controller.gameObject.SetActive(true);
        player2Controller.gameObject.SetActive(true);

        bot1Controller.gameObject.SetActive(false);
        bot2Controller.gameObject.SetActive(false);
    }
}
