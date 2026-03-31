using UnityEngine;

public class Debris : MonoBehaviour
{
    public Sprite playerwithScytheSprite;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trash"))
        {
           /// sr.sprite = ;
            Destroy(other.gameObject);
        }
    }
}