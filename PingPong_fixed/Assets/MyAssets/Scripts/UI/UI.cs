using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject menuWindow;
    [SerializeField] private Button botPlayerButton;
    [SerializeField] private Button playerButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button continueButton;

    void Start()
    {
        MenuIsActive();
    }

    public void MenuIsActive()
    {
        menuWindow.SetActive(true);
    }

    public void MenuIsActiveResume()
    {
        menuWindow.SetActive(true);
        botPlayerButton.gameObject.SetActive(false);
        playerButton.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(true);

        exitButton.transform.localPosition = new Vector3(10.1499996f, -32.3000145f, 0f);
    }

    public void CloseMenu()
    {
        menuWindow.SetActive(false);
    }
}
