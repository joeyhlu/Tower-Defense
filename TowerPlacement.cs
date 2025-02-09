using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public GameObject towerPrefab;  
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            
            Instantiate(towerPrefab, mouseWorldPos, Quaternion.identity);
        }
    }
}
