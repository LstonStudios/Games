using UnityEngine;

public class ColorTrigger : MonoBehaviour
{
    [SerializeField] private Color backgroundColor = Color.black;
    [SerializeField] private Color groundColor = Color.white;
    [SerializeField] private float transitionDuration = 0.5f;

    private Camera mainCamera;
    private bool hasTriggered = false;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !hasTriggered)
        {
            TriggerColorChange();
            hasTriggered = true;
        }
    }

    private void TriggerColorChange()
    {
        if (mainCamera != null)
        {
            mainCamera.backgroundColor = backgroundColor;
        }

        // Find ground renderer and change its color
        SpriteRenderer groundRenderer = FindObjectOfType<SpriteRenderer>();
        if (groundRenderer != null)
        {
            groundRenderer.color = groundColor;
        }

        Debug.Log($"Color changed: BG={backgroundColor}, Ground={groundColor}");
    }

    public void ResetTrigger()
    {
        hasTriggered = false;
    }
}
