
using UnityEngine;

public class Sol : MonoBehaviour
{
    AspetSol aspetSol;

    private void Start()
    {
        aspetSol = GameObject.FindObjectOfType<AspetSol>();
        SpawnObstacle();
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
}
