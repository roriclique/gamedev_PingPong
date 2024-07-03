using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManageDropdown : MonoBehaviour
{
    public TMP_Dropdown dropdownPlayers;
    public TMP_Dropdown dropdownModesOnePlayer;
    public TMP_Dropdown dropdownModesTwoPlayers;

    [SerializeField] private GameObject firstPlayer;
    [SerializeField] private GameObject secondPlayer;

    private List<string> optionsOfModesTwoPlayers = new List<string>();
    private string selectedOnePlayer;

    void Start()
    {
        foreach (TMP_Dropdown.OptionData option in dropdownModesTwoPlayers.options)
        {
            optionsOfModesTwoPlayers.Add(option.text);
        }

        dropdownPlayers.onValueChanged.AddListener(delegate { UpdatePlayers(); });
        dropdownModesOnePlayer.onValueChanged.AddListener(delegate { UpdateDropdownList(); });
        dropdownModesTwoPlayers.onValueChanged.AddListener(delegate { UpdatePlayers(); });

        UpdateDropdownList();
        UpdatePlayers();
    }

    public void UpdatePlayers()
    {
        int playersCount = dropdownPlayers.value + 1;
        string controlType = dropdownModesOnePlayer.options[dropdownModesOnePlayer.value].text;
        string controlType2 = dropdownModesTwoPlayers.options.Count > 0 ? dropdownModesTwoPlayers.options[dropdownModesTwoPlayers.value].text : "Mouse";

        SetupPlayerController(firstPlayer, controlType);

        if (playersCount == 1)
        {
            dropdownModesTwoPlayers.gameObject.SetActive(false);
            SetupPlayerController(secondPlayer, "Bot");
        }
        else if (playersCount == 2)
        {
            dropdownModesTwoPlayers.gameObject.SetActive(true);
            SetupPlayerController(secondPlayer, controlType2);
        }
    }

    private void UpdateDropdownList()
    {
        selectedOnePlayer = dropdownModesOnePlayer.options[dropdownModesOnePlayer.value].text;

        dropdownModesTwoPlayers.ClearOptions();

        foreach (string option in optionsOfModesTwoPlayers)
        {
            if (option != selectedOnePlayer)
            {
                dropdownModesTwoPlayers.options.Add(new TMP_Dropdown.OptionData(option));
            }
        }
        dropdownModesOnePlayer.RefreshShownValue();
        dropdownModesTwoPlayers.RefreshShownValue();
    }

    public void SetupPlayerController(GameObject player, string controlType)
    {
        Controller controller = player.GetComponent<Controller>();

        switch (controlType)
        {
            case "Mouse":
                controller.SetControlType(Controller.ControlType.Mouse);
                break;
            case "Keyboard":
                controller.SetControlType(Controller.ControlType.Keyboard);
                break;
            case "Bot":
                controller.SetControlType(Controller.ControlType.Bot);
                break;
        }
    }
}
