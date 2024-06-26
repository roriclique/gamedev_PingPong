using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private float fieldWidthUnits;
    [SerializeField] private Ball ball;

    public GameObject player1Controller;
    public GameObject player2Controller;
    public GameObject bot1Controller;
    public GameObject bot2Controller;

    private void Start()
    {
        if (gameObject.CompareTag("Bot"))
        {
            BotPlayerController();
        }
        else if (gameObject.CompareTag("Player"))
        {
            Player1Controller();
        }
        else if (gameObject.CompareTag("Player2"))
        {
            Player2Controller();
        }
    }
    void FixedUpdate()
    {
        Start();
    }

    public void Player1Controller()
    {
        //��������� ������� ����
        Vector3 mousePosition = Input.mousePosition;

        //���������� ������������ ��������� ���� ������ � ����
        float mousePosY = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.nearClipPlane)).y;

        //����������� ���������
        float clampedY = Mathf.Clamp(mousePosY, -fieldWidthUnits / 2, fieldWidthUnits / 2);

        //���������� ������� �������
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
    }

    public void Player2Controller()
    {
        //���������� �������� �� ��������� � ������� ������� �� �����
        float moveInput = Input.GetAxis("Vertical");

        //���������� ������� ������� �������
        float newY = transform.position.y + moveInput * (ball.speed * 5) * Time.deltaTime;

        //����������� ������ ���������
        float clampedY = Mathf.Clamp(newY, -fieldWidthUnits / 2, fieldWidthUnits / 2);

        //���������� ������� �������
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
    }

    public void BotPlayerController()
    {
        //���������� ������� ������� ���� (��������, ���, ����)
        float targetY = Mathf.Clamp(ball.transform.position.y, -fieldWidthUnits, fieldWidthUnits);

        //�������� ������������ ������ ��������� (��������� ��������, �������� ��������, ���������������� ��������)
        float newY = Mathf.Lerp(ball.transform.position.y, targetY, ball.speed * Time.deltaTime);

        //����������� ������ ���������
        float clampedY = Mathf.Clamp(newY, -fieldWidthUnits / 2, fieldWidthUnits / 2);

        if (Vector3.Distance(transform.position, ball.transform.position) <= 12f)
        {
            //���������� ������� �������
            transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
        }      
    }
}

