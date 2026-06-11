using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private int checkpointIndex = 0;
    private bool hasBeenActivated = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !hasBeenActivated)
        {
            ActivateCheckpoint();
        }
    }

    private void ActivateCheckpoint()
    {
        hasBeenActivated = true;
        LevelManager.Instance.SetCheckpoint(checkpointIndex);
        Debug.Log($"Checkpoint {checkpointIndex} activated!");

        // Visual feedback
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.green;
        }
    }

    public void Reset()
    {
        hasBeenActivated = false;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.white;
        }
    }
}
