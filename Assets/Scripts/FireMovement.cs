using UnityEngine;

public class FireMovement : MonoBehaviour
{
    private Vector3 normalizeDirection;
    public Transform target;
    [SerializeField] private float speed = 5f;

    void Start()
    {
        normalizeDirection = (target.position - transform.position).normalized;
    }

    void Update()
    {
        transform.position += normalizeDirection *speed * Time.deltaTime;
    }
}
