using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] float maxHealth = 100f;
    [SerializeField] float invulnerabilityDuration = 1f;
    [SerializeField] float blinkInterval = 0.1f;

    [SerializeField] private PlayerMovement PlayerMovement;

    Collider2D collider;
    float currentHealth;
    float invulnerabilityTimer;
    GameObject Player;

    SpriteRenderer sprite;
    float blinkTimer;
    bool blinking;

    void Awake()
    {
        currentHealth = maxHealth;
        sprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
        Player = GetComponent<GameObject>();
        PlayerMovement = GetComponent<PlayerMovement>();
    }

    void Start()
    {
        collider.enabled = true;
    }

    void Update()
    {
        if (invulnerabilityTimer > 0f)
            invulnerabilityTimer -= Time.deltaTime;

        HandleBlink();
    }

    public bool ApplyDamage(float amount)
    {

        screenShakeManager.Instance.Shake(15f,0.25f);
        if (currentHealth <= 0f || invulnerabilityTimer > 0f)
            return false;

        currentHealth -= amount;

        if (currentHealth <= 0f)
        {
            Die();
            return true;
        }

        invulnerabilityTimer = invulnerabilityDuration;
        StartBlink(invulnerabilityDuration);
        return true;
    }

    void StartBlink(float duration)
    {
        blinking = true;
        blinkTimer = duration;
    }

    void HandleBlink()
    {
        if (!blinking) return;

        blinkTimer -= Time.deltaTime;
        if (blinkTimer <= 0f)
        {
            blinking = false;
            sprite.enabled = true;
            return;
        }

        sprite.enabled =
            Mathf.FloorToInt(blinkTimer / blinkInterval) % 2 == 0;
    }

    void Die()
    {
        sprite.enabled = false;
        collider.enabled = false;
        PlayerMovement.enabled = false;
        
        StartCoroutine(Death());
        //SceneManager.LoadScene("MainMenu").Delay(3f);
    }

    IEnumerator Death()
    {
        
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("MainMenu");
    }
}