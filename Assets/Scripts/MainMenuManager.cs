using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public CanvasGroup MainMenu;
    public CanvasGroup OptionsMenu;

    public void playGame()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayOnBoot();
        }
        SceneManager.LoadScene("Level1");
    }


    public void quitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

#else 
Application.Quit();
#endif
    }
}
