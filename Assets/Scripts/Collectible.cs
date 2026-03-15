using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private playerFollow playerFollow;
    private bool collected = false;
    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.CompareTag("Player"))
        {
        if (collected)
        {
        return;
        }
            collected = true;
            AudioManager.Instance.PlaySFX(AudioManager.Instance.collectibleSFX);
            playerFollow.enabled = true;
            //Destroy(gameObject);
        }
    }
}
