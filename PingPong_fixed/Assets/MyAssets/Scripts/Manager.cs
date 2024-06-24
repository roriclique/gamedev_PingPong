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
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(menuIsActive)
            {
                MenuCloseToContinue();
            }
            else
            {
                MenuInvocation();
            }
        }
    }

    public void MenuInvocation()
    {
        menuWindow.MenuIsActive();
        menuIsActive = true;
        Time.timeScale = 0f;
    }

    public void MenuCloseToContinue()
    {
        menuWindow.CloseMenu();
        menuIsActive = false;
        Time.timeScale = 1f;
    }

    public void SetSingleMode()
    {
        menuWindow.CloseMenu();
        scoreCollector.StartScores();
        ball.rb.simulated = true;

        modes.SingleMode();
        ball.enabled = true;
    }

    public void SetMultiMode()
    {
        menuWindow.CloseMenu();
        scoreCollector.StartScores();
        ball.rb.simulated = true;

        modes.MultiMode();
        ball.enabled = true;
    }

    public void OnApplicationQuit()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }


}
