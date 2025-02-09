using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Tower Settings")]
    public float range = 3f;  
    public float fireRate = 1f;  

    public Transform firePoint;  
    [SerializeField] private Sprite bulletSprite; 

    private float fireCooldown = 0f; 

    void Update()
    {
        fireCooldown -= Time.deltaTime;

        EnemyPathMovement nearestEnemy = GetNearestEnemy();
        if (nearestEnemy != null)
        {
            if (fireCooldown <= 0f)
            {
                Debug.Log("tower shooting");

                Shoot(nearestEnemy.transform);

                fireCooldown = 1f / fireRate;
            }
        }
    }

    EnemyPathMovement GetNearestEnemy()
    {
        EnemyPathMovement[] enemies = FindObjectsOfType<EnemyPathMovement>();
        EnemyPathMovement nearest = null;
        float shortestDistance = Mathf.Infinity;

        foreach (var enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < shortestDistance && distance <= range)
            {
                shortestDistance = distance;
                nearest = enemy;
            }
        }

        return nearest;
    }


    void Shoot(Transform enemyTarget)
    {
        GameObject projectileGO = new GameObject("Projectile");

        SpriteRenderer sr = projectileGO.AddComponent<SpriteRenderer>();
        
        sr.sprite = bulletSprite;
        
        sr.color = Color.yellow;
        sr.sortingOrder = 10; 

        Projectile projectileComp = projectileGO.AddComponent<Projectile>();

        projectileComp.targetTransform = enemyTarget;

        projectileComp.speed = 5f;

        projectileGO.transform.position = firePoint.position;

        projectileGO.transform.rotation = firePoint.rotation;

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
