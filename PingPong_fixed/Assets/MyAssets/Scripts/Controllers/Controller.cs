using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private Ball ball;
    [SerializeField] private MainCameraWidth mainCameraWidth;
    private float fieldHeight;

    public enum ControlType { Mouse, Keyboard, Bot}
    private ControlType controlType;

    [SerializeField] private Transform playerTransform;

    public void SetControlType(ControlType type)
    {
        controlType = type;
    }

    private void Update()
    {
        fieldHeight = mainCameraWidth.topSide.transform.position.y * 2;

        switch (controlType)
        {
            case ControlType.Mouse:
                MousePlayerControl();
                break;
            case ControlType.Keyboard:
                KeyboardPlayerControl();
                break;
            case ControlType.Bot:
                BotPlayerControl();
                break;
        }
    }

    private void MousePlayerControl()
    {
        Vector3 mousePosition = Input.mousePosition;
        float mousePosY = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.nearClipPlane)).y;
        float clampedY = Mathf.Clamp(mousePosY, -fieldHeight / 2, fieldHeight / 2);
        playerTransform.position = new Vector3(playerTransform.position.x, clampedY, playerTransform.position.z);
    }

    private void KeyboardPlayerControl()
    {
        float moveInput = Input.GetAxis("Vertical");
        float newY = playerTransform.position.y + moveInput * (ball.speed * 5) * Time.deltaTime;
        float clampedY = Mathf.Clamp(newY, -fieldHeight / 2, fieldHeight / 2);
        playerTransform.position = new Vector3(playerTransform.position.x, clampedY, playerTransform.position.z);
    }

    private void BotPlayerControl()
    {
        float targetY = Mathf.Clamp(ball.transform.position.y, -fieldHeight, fieldHeight);
        float newY = Mathf.Lerp(ball.transform.position.y, targetY, ball.speed * Time.deltaTime);
        float clampedY = Mathf.Clamp(newY, -fieldHeight / 2, fieldHeight / 2);

        if (Vector3.Distance(playerTransform.position, ball.transform.position) <= 12f)
        {
            playerTransform.position = new Vector3(playerTransform.position.x, clampedY, playerTransform.position.z);
        }
    }
}

