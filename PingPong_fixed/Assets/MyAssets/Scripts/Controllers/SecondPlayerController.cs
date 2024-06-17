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
        float moveInput = Input.GetAxis("Vertical");
        float newY = transform.position.y + moveInput * (ball.speed * 5) * Time.deltaTime;
        float clampedY = Mathf.Clamp(newY, -fieldWidthUnits / 2, fieldWidthUnits / 2);

        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
    }
}
