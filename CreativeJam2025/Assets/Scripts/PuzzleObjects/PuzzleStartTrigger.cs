using UnityEngine;

public class PuzzleStartTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>() != null)
        {
            FindFirstObjectByType<CyclopsPuzzleSequence>().StartPuzzle();
            Destroy(gameObject);
        }
    }
}
