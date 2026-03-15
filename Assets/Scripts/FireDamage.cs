using UnityEngine;

public class FireDamage : MonoBehaviour
{
    [SerializeField] float damage = 3f;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.TryGetComponent(out IDamageable damageable))
        {
            damageable.ApplyDamage(damage);
            AudioManager.Instance.PlaySFX(AudioManager.Instance.deathSFX);
        }
    }
}