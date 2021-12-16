
using UnityEngine;

public class Sol : MonoBehaviour
{
    AspetSol aspetSol;

    private void Start()
    {
        aspetSol = GameObject.FindObjectOfType<AspetSol>();
        SpawnObstacle();
        SpawnCoins();
    }

 

    private void OnTriggerExit(Collider other)
    {
        aspetSol.PointSol();
        Destroy(gameObject, 2);
    

    }
    //Runner

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject obstaclePrefab;
    void SpawnObstacle()
    {
        //choisir un point au hasar pour afficher l'obstacle'
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
        //afficher l'obstacle a la position'
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    public GameObject coinPrefab;

    public void SpawnCoins()
    {
        int coinsToSpawn = 10;
        for (int i = 0; i < coinsToSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefab);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;
        return point;
    }
}
