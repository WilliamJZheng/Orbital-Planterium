using UnityEngine;

public class CollectibleSwap : MonoBehaviour
{
    public Sprite newPlayerSprite;
    public AudioClip pickupSound;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SpriteRenderer playerSR = other.GetComponent<SpriteRenderer>();
            AudioSource playerAudio = other.GetComponent<AudioSource>();

            if (playerSR != null && newPlayerSprite != null)
            {
                playerSR.sprite = newPlayerSprite;
            }

            if (playerAudio != null && pickupSound != null)
            {
                playerAudio.PlayOneShot(pickupSound);
            }

            Destroy(gameObject);
        }
    }
}