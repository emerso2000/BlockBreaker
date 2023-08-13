using UnityEngine;

public class BlackHoles : MonoBehaviour
{
    public new Rigidbody2D rigidbody { get; private set; }
    public float speed = 5f; // Adjust the speed as needed
    public float sizeIncreasePercentage = 0.25f; // 25%

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        MoveRandomly();
    }

    private void MoveRandomly()
    {
        Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        rigidbody.velocity = randomDirection * speed;

        // Call the function again after a random interval
        float randomInterval = Random.Range(1f, 3f);
        Invoke(nameof(MoveRandomly), randomInterval);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball referenceToBallHit = collision.gameObject.GetComponent<Ball>();

        if (referenceToBallHit != null) // Check if collided with the ball
        {
            Vector3 lastScale = referenceToBallHit.transform.localScale;
            lastScale = lastScale * 1.25f; // 25 percent larger
            referenceToBallHit.transform.localScale = lastScale; 
        }
    }
}