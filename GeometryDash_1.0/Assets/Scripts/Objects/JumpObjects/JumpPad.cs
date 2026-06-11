using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private bool isOrbType = false; // False = Pad, True = Orb

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ActivateJump(collision.rigidbody);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            ActivateJump(rb);
        }
    }

    private void ActivateJump(Rigidbody2D rb)
    {
        if (rb != null)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            Debug.Log($"Player jumped on {(isOrbType ? "Orb" : "Pad")}!");
        }
    }

    public void SetJumpForce(float force)
    {
        jumpForce = force;
    }
}
