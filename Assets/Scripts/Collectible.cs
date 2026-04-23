using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private playerFollow playerFollow;
    public ParticleSystem HeartsFX;
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
            HeartsFX.Play();
            playerFollow.enabled = true;
            //Destroy(gameObject);
        }
    }
}
