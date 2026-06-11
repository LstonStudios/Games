using UnityEngine;

public class ShipPortal : MonoBehaviour
{
    [SerializeField] private bool activateShipMode = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player != null)
            {
                player.SetShipMode(activateShipMode);
                Debug.Log($"Player entered ship portal: {activateShipMode}");
            }
        }
    }
}
