using UnityEngine;
using UnityEngine.Rendering;

public class CyclopsMudThrow : MonoBehaviour
{
    [SerializeField] private float spawnTimeMin;
    [SerializeField] private float spawnTimeMax;
    [SerializeField] private Animator cyclopsAnim;
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
            cyclopsAnim.Play("ThrowObject");

            //pick a random spawn time
            float spawnTime = Random.Range(spawnTimeMin, spawnTimeMax);
            spawnTimer = spawnTime;
        }


    }
}
