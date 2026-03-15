using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.CompareTag("Player"))
        {
          
            AudioManager.Instance.PlaySFX(AudioManager.Instance.collectibleSFX);
            SceneManager.LoadScene("MainMenu");

        }
    }
}