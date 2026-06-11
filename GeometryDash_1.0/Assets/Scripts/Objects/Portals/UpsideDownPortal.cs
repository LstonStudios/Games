using UnityEngine;

public class UpsideDownPortal : MonoBehaviour
{
    [SerializeField] private bool activateUpsideDown = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player != null)
            {
                player.SetUpsideDown(activateUpsideDown);
                Debug.Log($"Player entered upside-down portal: {activateUpsideDown}");
            }
        }
    }
}
