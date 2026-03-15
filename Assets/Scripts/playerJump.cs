using UnityEngine;
using System.Collections;

public class playerJump : MonoBehaviour
{
    [Header("Jump")]
    [SerializeField] private float jumpDuration = 0.6f;
    [SerializeField] private float jumpSize = 1.4f;

    [Header("Collision")]
    [SerializeField] private string obstacleLayerName = "Water";
    [SerializeField] private float landCheckRadius = 0.05f;

    private bool isJumping = false;
    private int playerLayer;
    private int obstacleLayer;
    private Vector3 originalScale;

    void Start()
    {
        playerLayer = gameObject.layer;
        obstacleLayer = LayerMask.NameToLayer(obstacleLayerName);
        originalScale = transform.localScale;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            StartCoroutine(Jump());
        }
    }

    IEnumerator Jump()
    {
        isJumping = true;

        Physics2D.IgnoreLayerCollision(playerLayer, obstacleLayer, true);

        float timePassed = 0f;
        while (timePassed < jumpDuration)
        {
            timePassed += Time.deltaTime;
            float percent = timePassed / jumpDuration;

            transform.localScale = originalScale * jumpSize;

            yield return null;
        }

        transform.localScale = originalScale;
        Physics2D.IgnoreLayerCollision(playerLayer, obstacleLayer, false);

        // Check if there is an obstacle when landing
        Collider2D land = Physics2D.OverlapCircle(transform.position, landCheckRadius, 1 << obstacleLayer);

        if (land != null)
        {
            gameObject.SetActive(false);
        }

        isJumping = false;
    }
}