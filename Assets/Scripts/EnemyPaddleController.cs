using UnityEngine;

public class EnemyPaddleController : MonoBehaviour
{
    public float speed = 3f;

    public Vector2 limits = new Vector2(-4.5f, 4.5f);

    private GameObject ball;

    private void Start()
    {
        ball = GameObject.Find("Ball");
    }

    private void Update()
    {
        if (ball != null)
        {
            float targetY = Mathf.Clamp(ball.transform.position.y, limits.x, limits.y); // Limite a posição Y
            Vector2 targetPosition = new Vector2(transform.position.x, targetY);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed); // Move gradualmente para a posição Y da bola
        }
    }
}
