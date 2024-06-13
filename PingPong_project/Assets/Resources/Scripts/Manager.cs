using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private Ball ball;
    [SerializeField] private UI menuWindow;
    [SerializeField] private Modes modes;

    void Start()
    {
        menuWindow.MenuIsActive();
    }

    public void SetSingleMode()
    {
        menuWindow.CloseMenu();

        modes.SingleMode();
        ball.enabled = true;
    }

    public void SetMultiMode()
    {
        menuWindow.CloseMenu();

        modes.MultiMode();
        ball.enabled = true;
    }
}
