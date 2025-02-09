using UnityEngine;

public class EnemyPathMovement : MonoBehaviour
{
    [Header("settings")]
    public float speed = 2f; 
    public Transform[] waypoints;
    private int waypointIndex = 0; 

    void Start()
    {
        transform.position = waypoints[0].position;
    }

    void Update()
    {
        MoveToNextWaypoint();
    }

    void MoveToNextWaypoint()
    {
        if (waypoints.Length == 0 || waypointIndex >= waypoints.Length)
            return;

        transform.position = Vector2.MoveTowards(
            transform.position,
            waypoints[waypointIndex].position,
            speed * Time.deltaTime
        );
        float distanceToWaypoint = Vector2.Distance(
            transform.position,
            waypoints[waypointIndex].position
        );

        if (distanceToWaypoint < 0.1f)
        {
            waypointIndex++;

            if (waypointIndex >= waypoints.Length)
            {
                Destroy(gameObject);
                Debug.Log("reached end");
            }
        }
    }
}
