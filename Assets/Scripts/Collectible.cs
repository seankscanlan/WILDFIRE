using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private float speedMultiplier = 1.5f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Destroy(gameObject);
        }
    }
}
