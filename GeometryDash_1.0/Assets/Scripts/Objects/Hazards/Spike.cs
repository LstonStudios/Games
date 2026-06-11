using UnityEngine;

public class Spike : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HandlePlayerCollision(collision.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HandlePlayerCollision(collision.gameObject);
        }
    }

    private void HandlePlayerCollision(GameObject player)
    {
        Debug.Log("Player hit spike!");
        GameManager.Instance.FailLevel();
    }
}
