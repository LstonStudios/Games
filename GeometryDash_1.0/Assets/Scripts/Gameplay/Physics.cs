using UnityEngine;

public class Physics : MonoBehaviour
{
    [SerializeField] private float customGravity = -9.81f;
    [SerializeField] private LayerMask collisionLayers;

    private Rigidbody2D rb;
    private bool useCustomGravity = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        if (useCustomGravity)
        {
            rb.gravityScale = 0;
        }
    }

    private void FixedUpdate()
    {
        if (useCustomGravity)
        {
            ApplyCustomGravity();
        }
    }

    private void ApplyCustomGravity()
    {
        rb.velocity += new Vector2(0, customGravity * Time.fixedDeltaTime);
    }

    public void EnableCustomGravity(bool enable)
    {
        useCustomGravity = enable;
        rb.gravityScale = enable ? 0 : 1;
    }
}
