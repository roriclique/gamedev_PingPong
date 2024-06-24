using UnityEngine;

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

    void Update()
    {
        rb.velocity = direction.normalized * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            direction.x = -direction.x;
            direction.y = Random.Range(-1f, 1f);
            speed += accelSpeed;
        }

        if (collision.gameObject.CompareTag("GameZone"))
        {
            direction.y = -direction.y;
            direction.x = Random.Range(-5f, 5f);
        }

        if (collision.gameObject.CompareTag("Score1Player") || collision.gameObject.CompareTag("Score2Player"))
        {
            transform.position = startPosition;
            direction = new Vector2(Random.Range(-3f, 3f), Random.Range(-0.5f, 0.5f));
            speed = startSpeed;
        }
    }
}
