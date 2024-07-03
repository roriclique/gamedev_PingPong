using UnityEngine;

public class MainCameraWidth : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject gamezoneHolder;

    public GameObject gamezoneTopSide;
    public GameObject gamezoneLeftSide;

    void Awake()
    {
        mainCamera = Camera.main;

        var height = Screen.height;
        var scaleY = height / mainCamera.rect.height;
        var width = Screen.width;
        var scaleX = width / mainCamera.rect.width;

        gamezoneHolder.transform.localScale = new Vector3(scaleX, scaleY, 1);
        mainCamera.orthographicSize = height / mainCamera.rect.height * 10;
    }
}
