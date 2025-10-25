using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int startingHearts;
    [SerializeField] private GameObject heartLayoutGroup; //UI horiz layout group
    [SerializeField] private GameObject heartUIPrefab;
    private int playerHearts;
    private List<GameObject> heartImages;

    private void Start()
    {
        playerHearts = startingHearts;
        heartImages = new List<GameObject>();

        //instantiate heart icons
        for (int i = 0; i < playerHearts; i++)
        {
            GameObject img = Instantiate(heartUIPrefab, heartLayoutGroup.transform);
            heartImages.Add(img);
        }
    }

    public void LoseHeart()
    {
        playerHearts--;
        if (heartImages[playerHearts] != null)
        {
            Destroy(heartImages[playerHearts]);
            heartImages.RemoveAt(playerHearts);
        }

        if (playerHearts == -1)
        {
            Destroy(gameObject);
        }
    }
}
