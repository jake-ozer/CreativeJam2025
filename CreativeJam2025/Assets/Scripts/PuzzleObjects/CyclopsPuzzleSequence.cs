using UnityEngine;

public class CyclopsPuzzleSequence : MonoBehaviour
{
    [SerializeField] private GameObject bossCanvas;
    [SerializeField] private CyclopsMudThrow mudThrow;
    [SerializeField] private SpawnMinions spawnMinions;
    [SerializeField] private AudioSource songPlayer;
    [SerializeField] private AudioClip bossSong;

    private bool puzzle1Completed = false;
    private bool puzzle2Completed = false;

    public void StartPuzzle()
    {
        songPlayer.clip = bossSong;
        songPlayer.Play();
        bossCanvas.SetActive(true);
        mudThrow.enabled = true;
        spawnMinions.enabled = true;
    }

    private void Update()
    {
        if (puzzle2Completed)
        {
            mudThrow.gameObject.GetComponent<CyclopsHealth>().shieldActive = false;
        }
    }
}
