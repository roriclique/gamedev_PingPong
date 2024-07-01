using Unity.VisualScripting;
using UnityEngine;

public class MainCameraWidth : MonoBehaviour
{
    public Camera mainCamera;
    [SerializeField] private GameObject gamezoneHolder;

    [SerializeField] public GameObject topSide;
    [SerializeField] public GameObject leftSide;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        var height = Screen.height;
        var scaleY = height / mainCamera.rect.height;
        var width = Screen.width;
        var scaleX = width / mainCamera.rect.width;

        gamezoneHolder.transform.localScale = new Vector3(scaleX, scaleY, 1);
        mainCamera.orthographicSize = height / mainCamera.rect.height * 10;
    }
}
