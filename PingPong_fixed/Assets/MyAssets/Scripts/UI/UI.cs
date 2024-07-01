using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject menuWindow;
    [SerializeField] private TMP_Dropdown dropdownPlayers;
    [SerializeField] private TMP_Dropdown dropdownModes;
    [SerializeField] private TMP_Dropdown dropdownModes2;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button goButton;

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
        dropdownPlayers.gameObject.SetActive(false);
        dropdownModes.gameObject.SetActive(false);
        dropdownModes2.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        goButton.gameObject.SetActive(false);

        exitButton.transform.localPosition = new Vector3(10.1499996f, -32.3000145f, 0f);
    }

    public void CloseMenu()
    {
        menuWindow.SetActive(false);
    }
}
