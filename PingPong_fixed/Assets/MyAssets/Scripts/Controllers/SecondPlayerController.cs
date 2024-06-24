using UnityEngine;

public class SecondPlayerController : MonoBehaviour
{
    [SerializeField] private float fieldWidthUnits;
    [SerializeField] private Ball ball;

    void Update()
    {
        Player2Controller();
    }

    public void Player2Controller()
    {
        //Управление объектом по вертикали с помощью стрелок на клаве
        float moveInput = Input.GetAxis("Vertical");

        //Вычисление целевой позиции объекта
        float newY = transform.position.y + moveInput * (ball.speed * 5) * Time.deltaTime;

        //Ограничение нового положения
        float clampedY = Mathf.Clamp(newY, -fieldWidthUnits / 2, fieldWidthUnits / 2);

        //Обновление позиции объекта
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
    }
}
