using UnityEngine;
using System;

public class Manager : MonoBehaviour
{
    [SerializeField] private Ball ball;

    [SerializeField] private UI menuWindow;
    [SerializeField] private ScoreCollector scoreCollector;
    [SerializeField] private Modes modes;

    [SerializeField] private GameObject sceneToDisable;

    private bool menuIsActive;

    void Start()
    {
        sceneToDisable.SetActive(true);
        menuWindow.MenuIsActive();
        Time.timeScale = 0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuInvocation();
        }
    }

    public void MenuInvocation()
    {
        menuWindow.MenuIsActiveResume();
        //menuIsActive = true;
        Time.timeScale = 0f;
    }

    public void MenuCloseToContinue()
    {
        menuWindow.CloseMenu();
        //menuIsActive = false;
        Time.timeScale = 1f;
    }

    public void SetBotMode()
    {
        menuWindow.CloseMenu();
        scoreCollector.StartScores();
        modes.BotMode();

        Time.timeScale = 1f;
    }

    public void SetMultiMode()
    {
        menuWindow.CloseMenu();
        scoreCollector.StartScores();
        modes.MultiMode();

        Time.timeScale = 1f;
    }

    public void OnApplicationQuit()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }


}
