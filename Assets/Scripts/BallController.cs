using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector2 startingVelocity = new Vector2(5f, 5f);

    public GameManager gameManager;

    public float speedUp = 1.1f;

    private Vector2 lastStartVelocity;

    private void Awake()
    {
        lastStartVelocity = startingVelocity;
    }

    public void ResetBall()
    {
        transform.position = Vector3.zero;

        if (rb == null) rb = GetComponent<Rigidbody2D>();
        rb.velocity = lastStartVelocity;
        lastStartVelocity = new Vector2(-lastStartVelocity.x, GetRandomY());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector2 newVelocity = rb.velocity;

            newVelocity.y = -newVelocity.y;
            rb.velocity = newVelocity;
        }

        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
            rb.velocity *= speedUp;
        }

        if (collision.gameObject.CompareTag("WallEnemy"))
        {
            gameManager.ScorePlayer();
            ResetBall();
        }
        else if (collision.gameObject.CompareTag("WallPlayer"))
        {
            gameManager.ScoreEnemy();
            ResetBall();
        }
    }

    private float GetRandomY()
    {
        int random = (int)Random.Range(0f, 1f);
        random = random == 0 ? -1 : random;
        return random * lastStartVelocity.y;
    }
}
