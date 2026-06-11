using UnityEngine;

public class CubePortal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player != null)
            {
                player.SetShipMode(false);
                Debug.Log("Player entered cube portal");
            }
        }
    }
}
