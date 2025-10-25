using UnityEngine;

public class IceProjectile : MonoBehaviour
{
    [SerializeField] private float dmg;
    [SerializeField] private AudioClip impact;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.transform.root.gameObject.GetComponent<CyclopsHealth>() != null)
        {
            collision.gameObject.transform.root.gameObject.GetComponent<CyclopsHealth>().TakeDamage(dmg);
        }
        GetComponent<AudioSource>().PlayOneShot(impact);
        this.gameObject.GetComponent<Collider>().enabled = false;
        for (int i = 0; i < this.transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        Destroy(gameObject, 5f);
    }
}
