using UnityEngine;

public class ButtonTriggerSound : MonoBehaviour
{
    public AudioSource targetAudioSource;
    public Sprite pressedSprite;

    private bool hasTriggered = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;

         
            if (targetAudioSource != null)
            {
                targetAudioSource.Play();
            }

           
            if (pressedSprite != null)
            {
                SpriteRenderer sr = GetComponent<SpriteRenderer>();
                if (sr != null)
                {
                    sr.sprite = pressedSprite;
                }
            }
        }
    }
}