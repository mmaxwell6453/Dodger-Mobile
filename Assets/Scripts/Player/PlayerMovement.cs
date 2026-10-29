using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float moveInput;
    public float screenPadding = 0.5f;

    private float moveAction;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        animator.SetFloat("Speed", Mathf.Abs(moveInput));
        spriteRenderer.flipX = moveInput < 0 ? true : false;
        KeepPlayerOnScreen();
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<float>();
    }

    void KeepPlayerOnScreen()
    {
        float halfPlayerWidth = spriteRenderer.bounds.extents.x;

        float leftEdge = Camera.main.ViewportToWorldPoint(
            new Vector3(0, 0, 0)
        ).x;

        float rightEdge = Camera.main.ViewportToWorldPoint(
            new Vector3(1, 0, 0)
        ).x;

        Vector3 position = transform.position;

        position.x = Mathf.Clamp(
            position.x,
            leftEdge + halfPlayerWidth + screenPadding,
            rightEdge - halfPlayerWidth - screenPadding
        );

        transform.position = position;
    }
}
