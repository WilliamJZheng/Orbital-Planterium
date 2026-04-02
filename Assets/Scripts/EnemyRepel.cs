using UnityEngine;

public class EnemyRepel : MonoBehaviour
{
    public float forceX = 25f;
    public float forceY = 3f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                float dir = collision.transform.position.x < transform.position.x ? -1f : 1f;
                rb.linearVelocity = new Vector2(dir * forceX, forceY);
            }
        }
    }
}