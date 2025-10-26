using UnityEngine;

public class CyclopsPuzzleSequence : MonoBehaviour
{
    [SerializeField] private GameObject bossCanvas;
    [SerializeField] private CyclopsMudThrow mudThrow;
    [SerializeField] private SpawnMinions spawnMinions;
    [SerializeField] private AudioSource songPlayer;
    [SerializeField] private AudioClip bossSong;
    [SerializeField] private ArrowSpinner arrowSpinner;

    public bool puzzle1Completed = false;
    public bool puzzle2Completed = false;

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
        if (puzzle1Completed)
        {
            if (arrowSpinner.IsCorrectAnswer())
            {
                arrowSpinner.canSpin = false;
                puzzle2Completed = true;
            }
        }

        if (puzzle2Completed)
        {
            //make boss weak to ice
            mudThrow.gameObject.GetComponent<CyclopsHealth>().shieldActive = false;
        }
    }
}
