using UnityEngine;
using System;

public class Manager : MonoBehaviour
{
    [SerializeField] private static Ball ball;

    [SerializeField] private UI menuWindow;
    [SerializeField] private GameObject sceneToDisable;


    [SerializeField] private Controller controller1Player;
    [SerializeField] private Controller controller2Player;

    private bool isActiveMenu;

    void Start()
    {
        menuWindow.MenuIsActive();
        isActiveMenu = true;
        Time.timeScale = 0f;
    }

    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuInvocation();
        }

        if (isActiveMenu)
        {
            controller1Player.enabled = false;
            controller2Player.enabled = false;
        }
        else
        {
            controller1Player.enabled = true;
            controller2Player.enabled = true;
        }
    }

    public void MenuInvocation()
    {
        menuWindow.MenuIsActiveResume();
        isActiveMenu = true;
        Time.timeScale = 0f;
    }

    public void MenuCloseToContinue()
    {
        menuWindow.CloseMenu();
        isActiveMenu = false;
        Time.timeScale = 1f;
    }

    public void OnApplicationQuit()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        sceneToDisable.SetActive(false);
#endif
    }


}
