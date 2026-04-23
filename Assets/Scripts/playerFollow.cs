using UnityEngine;

public class playerFollow : MonoBehaviour
{
    private GameObject wayPoint;
    public ParticleSystem SmokeFX;
    [SerializeField] private Vector3 wayPointPos;
    [SerializeField] private float speed = 6.0f;

    // Adjust this value to set how far away the zombie stops
    [SerializeField] private float stoppingDistance = 1.5f;

    void Start()
    {
        wayPoint = GameObject.Find("wayPoint");
    }

    void Update()
    {
        wayPointPos = new Vector3(wayPoint.transform.position.x, wayPoint.transform.position.y, wayPoint.transform.position.z);

        // Calculate the distance to the player
        float distance = Vector3.Distance(transform.position, wayPointPos);

        // Only move if the zombie is further away than the stopping distance
        if (distance > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, wayPointPos, speed * Time.deltaTime);
            SmokeFX.Play();
        }
    }
}