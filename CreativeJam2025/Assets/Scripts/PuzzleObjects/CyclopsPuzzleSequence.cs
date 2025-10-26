using UnityEngine;

public class CyclopsPuzzleSequence : MonoBehaviour
{
    [SerializeField] private GameObject bossCanvas;
    [SerializeField] private CyclopsMudThrow mudThrow;
    [SerializeField] private SpawnMinions spawnMinions;
    [SerializeField] private AudioSource songPlayer;
    [SerializeField] private AudioClip bossSong;
    [SerializeField] private ArrowSpinner arrowSpinner;

    [SerializeField] private Pedestal[] pedestals;

    public GameObject lanternLight1;
    public GameObject lanternLight2;

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
            lanternLight1.SetActive(true);
        }
        if (puzzle2Completed)
        {
            lanternLight2.SetActive(true);
        }

        int fillCount = 0;
        foreach (Pedestal pedestal in pedestals)
        {
            if(pedestal.pedestalOrb != null)
            {
                fillCount++;
            }
        }
        if (fillCount >= pedestals.Length)
        {
            //check if its correct configuration, if so puzzle 1 is done
            int correctCount = 0;
            foreach (Pedestal pedestal in pedestals)
            {
                if (pedestal.IsCorrect())
                {
                    correctCount++;
                }
            }
            if (correctCount >= pedestals.Length)
            {
                puzzle1Completed = true;
            }

            Invoke("DestroyAllOrbs", 1.5f);
        }


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

    private void DestroyAllOrbs()
    {
        //delete all orbs
        Orb[] allOrbs = FindObjectsByType<Orb>(FindObjectsSortMode.None);
        foreach (Orb orb in allOrbs)
        {
            Destroy(orb.gameObject);
        }
    }
}
