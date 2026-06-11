using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float groundDrag = 5f;
    [SerializeField] private float airDrag = 2f;
    [SerializeField] private float gravityScale = 2f;

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private bool canJump = true;
    private bool isShipMode = false;
    private bool isUpsideDown = false;

    private Vector2 velocity = Vector2.zero;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (GameManager.Instance.IsPaused)
            return;

        HandleInput();
        UpdateDrag();
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.IsPaused)
            return;

        ApplyGravity();
        MoveHorizontally();
        CheckGrounded();
    }

    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (isShipMode)
            {
                ApplyShipMovement();
            }
            else if (canJump && isGrounded)
            {
                Jump();
            }
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * jumpForce * (isUpsideDown ? -1 : 1), ForceMode2D.Impulse);
        canJump = false;
    }

    private void ApplyShipMovement()
    {
        float direction = isUpsideDown ? -1 : 1;
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + (5f * direction));
    }

    private void MoveHorizontally()
    {
        float speed = moveSpeed * GameManager.Instance.GameSpeed;
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    private void UpdateDrag()
    {
        rb.drag = isGrounded ? groundDrag : airDrag;
    }

    private void ApplyGravity()
    {
        float direction = isUpsideDown ? 1 : -1;
        rb.gravityScale = gravityScale * direction;
    }

    private void CheckGrounded()
    {
        Vector3 rayStart = transform.position;
        float rayDistance = 0.1f;
        Vector3 rayDirection = isUpsideDown ? Vector3.up : Vector3.down;

        RaycastHit2D hit = Physics2D.Raycast(rayStart, rayDirection, rayDistance, LayerMask.GetMask("Ground"));

        isGrounded = hit.collider != null;

        if (isGrounded)
        {
            canJump = true;
        }
    }

    public void SetShipMode(bool shipMode)
    {
        isShipMode = shipMode;
        rb.gravityScale = shipMode ? 0.5f : gravityScale;
    }

    public void SetUpsideDown(bool upsideDown)
    {
        isUpsideDown = upsideDown;
        transform.rotation = upsideDown ? Quaternion.Euler(0, 0, 180) : Quaternion.identity;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        {
            Die();
        }
    }

    private void Die()
    {
        GameManager.Instance.FailLevel();
    }

    public bool IsGrounded => isGrounded;
    public bool IsShipMode => isShipMode;
    public bool IsUpsideDown => isUpsideDown;
}
