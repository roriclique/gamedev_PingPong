using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    [HideInInspector] public float speed = 13f;

    private float accelSpeed = 0.2f;
    private Vector2 direction;
    private Vector2 startPosition;
    private float startSpeed;
    public Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = new Vector2(Random.Range(-3f, 3f), Random.Range(-0.5f, 0.5f));
        startPosition = transform.position;
        startSpeed = speed;
    }

    void FixedUpdate()
    {
        rb.velocity = direction.normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Player2"))
        {
            direction.x = -direction.x;
            direction.y = Random.Range(-1f, 1f);
            speed += accelSpeed;
        }

        if (collision.gameObject.CompareTag("Bot"))
        {
            direction.x = -direction.x;
            direction.y = Random.Range(-1f, 1f);
            speed += accelSpeed;
        }

        if (collision.gameObject.CompareTag("GameZone"))
        {
            Vector2 normal = new Vector2(0, 1);
            float newPos = direction.x * normal.x + direction.y * normal.y;
            direction = direction - 2 * newPos * normal;
        }

        if (collision.gameObject.CompareTag("Score1Player") || collision.gameObject.CompareTag("Score2Player"))
        {
            transform.position = startPosition;
            direction = new Vector2(Random.Range(-3f, 3f), Random.Range(-0.5f, 0.5f));
            speed = startSpeed;
        }
    }
}
