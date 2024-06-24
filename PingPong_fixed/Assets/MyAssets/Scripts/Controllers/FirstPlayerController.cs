using UnityEngine;

public class FirstPlayerController : MonoBehaviour
{
    [SerializeField] private float fieldWidthUnits;

    void Update()
    {
        Player1Controller();
    }
    public void Player1Controller()
    {
        //Получение позиции мыши
        Vector3 mousePosition = Input.mousePosition;

        //Интеграция фактического положение мыши игрока в игру
        float mousePosY = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.nearClipPlane)).y;

        //Ограничение положения
        float clampedY = Mathf.Clamp(mousePosY, -fieldWidthUnits / 2, fieldWidthUnits / 2);

        //Обновление позиции объекта
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
    }

}
