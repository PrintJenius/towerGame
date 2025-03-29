using UnityEngine;

public class ObjectDetector : MonoBehaviour
{
    [SerializeField]
    private TowerSpawner towerSpawner;
    
    private Camera mainCamera;
    private Ray ray;
    private RaycastHit hit;

    private void Awake()
    {
        // "mainCamera" 태그를 가지고 있는 오브젝트 탐색 후 Camera 컴포넌트 정보 전달
        // GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>(); 와 동일
        mainCamera = Camera.main;    
    }

    private void Update()
    {
        if ( Input.GetMouseButtonDown(0) )
        {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if ( Physics.Raycast(ray, out hit, Mathf.Infinity) )
            {
                if ( hit.transform.CompareTag("Tile") )
                {
                    towerSpawner.SpawnTower(hit.transform);
                }
            }
        }
    }
}
