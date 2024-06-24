using UnityEngine;

public class BotController : MonoBehaviour
{
    [SerializeField] private float fieldWidthUnits;
    [SerializeField] private Ball ball;
    //private float paddleSpeedDelay = 15f;

    void Update()
    {
        BotPlayerController();
    }
    public void BotPlayerController()
    {
        //¬ычисление целевой позиции м€ча (значение, мин, макс)
        float targetY = Mathf.Clamp(ball.transform.position.y, -fieldWidthUnits, fieldWidthUnits);

        //Ћинейна€ интерпол€ци€ нового положени€ (начальное значение, конечное значение, интерпол€ционный параметр)
        float newY = Mathf.Lerp(ball.transform.position.y, targetY, ball.speed * Time.deltaTime);

        //ќграничение нового положени€
        float clampedY = Mathf.Clamp(newY, -fieldWidthUnits / 2, fieldWidthUnits / 2);

        //ќбновление позиции объекта
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
    }
}
