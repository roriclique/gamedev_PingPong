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
        Vector3 mousePosition = Input.mousePosition;
        float mousePosY = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.nearClipPlane)).y;
        float clampedY = Mathf.Clamp(mousePosY, -fieldWidthUnits / 2, fieldWidthUnits / 2);

        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
    }

}
