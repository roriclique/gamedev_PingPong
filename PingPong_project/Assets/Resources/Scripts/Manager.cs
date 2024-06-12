using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] private Ball ball;
    [SerializeField] private UI menuWindow;
    [SerializeField] private Mods mods;

    void Start()
    {
        menuWindow.MenuIsActive();
    }

    public void SetSingleMode()
    {
        menuWindow.CloseMenu();

        mods.SingleMode();
        ball.enabled = true;
    }

    public void SetSMultiMode()
    {
        menuWindow.CloseMenu();

        mods.MultiMode();
        ball.enabled = true;
    }
}
