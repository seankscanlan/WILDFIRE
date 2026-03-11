using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class animalHealth : MonoBehaviour, IDamageable
{
    [SerializeField] float maxHealth = 1f;

    static public float currentHealth;

    SpriteRenderer sprite;

    void Awake()
    {
        currentHealth = maxHealth;
        sprite = GetComponent<SpriteRenderer>();
    }

    public bool ApplyDamage(float amount)
    {

        screenShakeManager.Instance.Shake(15f,0.25f);
        if (currentHealth <= 0f)
            return false;

        currentHealth -= amount;

        if (currentHealth <= 0f)
        {
            Die();
            return true;
        }
        return true;
    }

    void Die()
    {
        gameObject.SetActive(false);
    }
}