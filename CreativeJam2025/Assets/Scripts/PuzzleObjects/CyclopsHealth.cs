using UnityEngine;
using UnityEngine.UI;

public class CyclopsHealth : MonoBehaviour
{
    [SerializeField] private float cyclopsMaxhealth;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private AudioClip ogreScreech;
    private float curHealth;
    public bool shieldActive;

    private void Start()
    {
        healthSlider.maxValue = cyclopsMaxhealth;
        healthSlider.value = cyclopsMaxhealth;
        curHealth = cyclopsMaxhealth;
        shieldActive = true;
    }

    public void TakeDamage(float dmg)
    {
        GetComponent<AudioSource>().PlayOneShot(ogreScreech);

        if (shieldActive)
        {
            curHealth -= 0.2f;
        }
        else 
        {
            curHealth -= dmg;
        }
        healthSlider.value = curHealth;
    }
}
