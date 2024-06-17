using UnityEngine;

public class BotController : MonoBehaviour
{
    [SerializeField] private float fieldWidthUnits;
    [SerializeField] private Ball ball;
    private float paddleSpeedDelay = 6f;

    void Update()
    {
        BotPlayerController();
    }
    public void BotPlayerController()
    {
        float targetY = Mathf.Clamp(ball.transform.position.y, -fieldWidthUnits, fieldWidthUnits);
        float newY = Mathf.Lerp(ball.transform.position.y, targetY, (ball.speed / paddleSpeedDelay) * Time.deltaTime);
        float clampedY = Mathf.Clamp(newY, -fieldWidthUnits / 2, fieldWidthUnits / 2);

        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
    }
}
