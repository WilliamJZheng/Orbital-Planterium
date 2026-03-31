using UnityEngine;

public class ScythePickup : MonoBehaviour
{
    public Sprite scytheSprite;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Scythe"))
        {
            sr.sprite = scytheSprite;
            Destroy(other.gameObject);
        }
    }
}