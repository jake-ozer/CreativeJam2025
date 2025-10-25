using UnityEngine;

public class SpawnMinions : MonoBehaviour
{
    [SerializeField] private float spawnTimeMin;
    [SerializeField] private float spawnTimeMax;
    [SerializeField] private GameObject minionPrefab;
    [SerializeField] private Transform minionSpawnTransform;
    private float spawnTimer;


    private void Start()
    {
        //pick a random spawn time
        float spawnTime = Random.Range(spawnTimeMin, spawnTimeMax);
        spawnTimer = spawnTime;
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer < 0)
        {
            Instantiate(minionPrefab, minionSpawnTransform.position, Quaternion.identity);

            //pick a random spawn time
            float spawnTime = Random.Range(spawnTimeMin, spawnTimeMax);
            spawnTimer = spawnTime;
        }

        
    }
}
