using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Projectile Settings")]
    public float speed = 2f; 

    [Header("Target")]
    public Transform targetTransform;

    void Update()
    {
        if (targetTransform == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector2 direction = targetTransform.position - transform.position;

        float distanceThisFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            Destroy(targetTransform.gameObject);
            Debug.Log("enemy dead");

            Destroy(gameObject);
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Debug.Log("enemy hit and dead");

            Destroy(gameObject);
        }
    }
}
