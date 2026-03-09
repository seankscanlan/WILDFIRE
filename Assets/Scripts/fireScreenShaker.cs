using UnityEngine;

public class fireScreenShaker : MonoBehaviour
{

    [SerializeField] private float shakeStrength = 5f;
    void OnTriggerStay2D(Collider2D other)
    {
        screenShakeManager.Instance.Shake(shakeStrength,0.25f);
    }
}
