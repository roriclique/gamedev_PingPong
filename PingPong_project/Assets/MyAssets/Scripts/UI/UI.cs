using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject menuWindow;
    [SerializeField] private GameObject onePlayerButton;
    [SerializeField] private GameObject twoPlayersButton;

    void Start()
    {
        MenuIsActive();
    }

    public void MenuIsActive()
    {
        menuWindow.SetActive(true);
    }

    public void CloseMenu()
    {
        menuWindow.SetActive(false);
    }
}
