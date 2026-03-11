using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private float speedMultiplier = 1.5f;
    [SerializeField] private playerFollow playerFollow;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.collectibleSFX);
            playerFollow.enabled = true;
            //Destroy(gameObject);
        }
    }
}
