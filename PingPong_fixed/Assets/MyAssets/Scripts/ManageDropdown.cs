using TMPro;
using UnityEngine;

public class ManageDropdown : MonoBehaviour
{
    public TMP_Dropdown dropdownPlayers;
    public TMP_Dropdown dropdownModesOnePlayer;
    public TMP_Dropdown dropdownModesTwoPlayers;

    [SerializeField] private GameObject firstPlayer;
    [SerializeField] private GameObject secondPlayer;

    void Start()
    {
        dropdownPlayers.onValueChanged.AddListener(delegate { UpdatePlayers(); });
        dropdownModesOnePlayer.onValueChanged.AddListener(delegate { UpdatePlayers(); });
        dropdownModesTwoPlayers.onValueChanged.AddListener(delegate { UpdatePlayers(); });

        UpdatePlayers();
    }

    public void UpdatePlayers()
    {
        int playersCount = dropdownPlayers.value + 1;
        string controlType = dropdownModesOnePlayer.options[dropdownModesOnePlayer.value].text;
        string controlType2 = dropdownModesTwoPlayers.options[dropdownModesTwoPlayers.value].text;

        SetupPlayerController(firstPlayer, controlType);

        if (playersCount == 1)
        {
            SetupPlayerController(secondPlayer, "Bot");
        }
        else if (playersCount == 2)
        {
            dropdownModesTwoPlayers.gameObject.SetActive(true);

            SetupPlayerController(secondPlayer, controlType2);
        }
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
