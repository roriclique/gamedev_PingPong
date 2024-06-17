using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject menuWindow;

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
