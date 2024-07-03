using UnityEngine;

public class Controller : MonoBehaviour
{
    public Ball ball;
    [SerializeField] private GameObject ballObj;

    public MainCameraWidth mainCameraWidth;

    public enum ControlType { Mouse, Keyboard, Bot}
    private ControlType controlType;

    [SerializeField] private Transform currentObjTransform;
    [SerializeField] private Transform player1Transform;
    [SerializeField] private Transform player2Transform;

    private float fieldHeight;

    //Расстояние от левой стороны GameZone до стандартного положения объекта игрока на сцене
    private float standardPaddlePos = 1.39f;

    public void SetControlType(ControlType type)
    {
        controlType = type;
    }

    private void Start()
    {
        fieldHeight = mainCameraWidth.gamezoneTopSide.transform.position.y * 2;

        Vector3 firstPlayerPos = new Vector3(mainCameraWidth.gamezoneLeftSide.transform.position.x / standardPaddlePos, 0, 0);
        player1Transform.transform.localPosition = firstPlayerPos;

        Vector3 secondPlayerPos = new Vector3(-firstPlayerPos.x, 0, 0);
        player2Transform.transform.localPosition = secondPlayerPos;

    }

    public void Update()
    {
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

    public void MousePlayerControl()
    {
        Vector3 mousePosition = Input.mousePosition;
        float mousePosY = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.nearClipPlane)).y;
        float clampedY = Mathf.Clamp(mousePosY, -fieldHeight / 2, fieldHeight / 2);
        currentObjTransform.transform.position = new Vector3(currentObjTransform.transform.position.x, clampedY, currentObjTransform.transform.position.z);
    }

    public void KeyboardPlayerControl()
    {
        float moveInput = Input.GetAxis("Vertical");
        float newY = currentObjTransform.transform.position.y + moveInput * (ball.speed * 5) * Time.deltaTime;
        float clampedY = Mathf.Clamp(newY, -fieldHeight / 2, fieldHeight / 2);
        currentObjTransform.transform.position = new Vector3(currentObjTransform.transform.position.x, clampedY, currentObjTransform.transform.position.z);
    }

    public void BotPlayerControl()
    {
        float targetY = Mathf.Clamp(ball.transform.position.y, -fieldHeight, fieldHeight);
        float newY = Mathf.Lerp(ball.transform.position.y, targetY, ball.speed * Time.deltaTime);
        float clampedY = Mathf.Clamp(newY, -fieldHeight / 2, fieldHeight / 2);

        if (Vector3.Distance(currentObjTransform.transform.position, ball.transform.position) <= 12f)
        {
            currentObjTransform.transform.position = new Vector3(currentObjTransform.transform.position.x, clampedY, currentObjTransform.transform.position.z);
        }
    }
}

