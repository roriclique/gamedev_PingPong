using UnityEngine;


public class Ball : MonoBehaviour
{
    [HideInInspector] public float speed = 5f;

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
        Vector2 normal = collision.contacts[0].normal;
        float newPos = direction.x * normal.x + direction.y * normal.y;
        
        if (collision.gameObject.CompareTag("Player"))
        {
            direction = direction - 2 * newPos * normal;
            speed += accelSpeed;

            Debug.Log("Direction after Player: " + direction);
        }

        else if (collision.gameObject.CompareTag("Player2"))
        {
            direction = direction - 2 * newPos * normal;
            speed += accelSpeed;

            Debug.Log("Direction after Player2: " + direction);
        }

        else if (collision.gameObject.CompareTag("Shape"))
        {
            direction = direction - 2 * newPos * normal;
            
            Debug.Log("Direction after Shape: " + direction);
        }

        else if (collision.gameObject.CompareTag("GameZone"))
        {
            direction = direction - 2 * newPos * normal;
            speed += accelSpeed;

            Debug.Log("Direction after GameZone: " + direction);
        }

        else if (collision.gameObject.CompareTag("Score1Player") || collision.gameObject.CompareTag("Score2Player"))
        {
            transform.position = startPosition;
            direction = new Vector2(Random.Range(-3f, 3f), Random.Range(-0.5f, 0.5f));
            speed = startSpeed;
        }
    }
}
