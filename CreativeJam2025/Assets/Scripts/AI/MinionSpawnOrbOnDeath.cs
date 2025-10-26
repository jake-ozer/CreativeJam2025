using NUnit.Framework;
using UnityEngine;

public class MinionSpawnOrbOnDeath : MonoBehaviour
{
    public GameObject[] possibleOrbs;

    private void OnDestroy()
    {
        if (FindFirstObjectByType<CyclopsPuzzleSequence>().puzzle1Completed == false)
        {
            int randomOrbIndex = Random.Range(0, possibleOrbs.Length);
            Instantiate(possibleOrbs[randomOrbIndex], transform.position, Quaternion.identity);
        }
    }
}
