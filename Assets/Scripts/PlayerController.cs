using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float jumpForce = 9f;

    public AudioClip jumpSound;
    public AudioClip walkSound;

    private Rigidbody2D rb;
    private bool isGrounded = false;

    private AudioSource audioSource;   // for jump
    private AudioSource walkSource;    // for walking

    private float originalScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // store original size so we don't shrink
        originalScale = Mathf.Abs(transform.localScale.x);

        // jump sound
        audioSource = GetComponent<AudioSource>();

        // walking sound setup
        walkSource = gameObject.AddComponent<AudioSource>();
        walkSource.clip = walkSound;
        walkSource.loop = true;
        walkSource.playOnAwake = false;
        walkSource.volume = 0.3f;
    }

    void FixedUpdate()
    {
        float moveInput = 0;

        if (Input.GetKey(KeyCode.LeftArrow)) moveInput = -1;
        if (Input.GetKey(KeyCode.RightArrow)) moveInput = 1;

        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // flip character without resizing
        if (moveInput > 0)
            transform.localScale = new Vector3(originalScale, transform.localScale.y, transform.localScale.z);

        if (moveInput < 0)
            transform.localScale = new Vector3(-originalScale, transform.localScale.y, transform.localScale.z);

        // walking sound
        if (moveInput != 0 && isGrounded)
        {
            if (!walkSource.isPlaying)
                walkSource.Play();
        }
        else
        {
            walkSource.Stop();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

            if (jumpSound != null)
                audioSource.PlayOneShot(jumpSound);

            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }
}