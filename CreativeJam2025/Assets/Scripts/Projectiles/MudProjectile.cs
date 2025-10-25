using UnityEngine;

public class MudProjectile : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
/*        if (collision.gameObject.GetComponent<PlayerHealth>() != null)
        {
            collision.gameObject.GetComponent<PlayerHealth>().LoseHeart();
            Destroy(this.gameObject);
        }*/

/*        if (collision.gameObject.GetComponent<FireballProjectile>() != null || collision.gameObject.GetComponent<IceProjectile>() != null)
        {
            Destroy(this.gameObject);
        }*/
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<PlayerHealth>() != null)
        {
            collision.gameObject.GetComponent<PlayerHealth>().LoseHeart();
            Destroy(this.gameObject);
        }

        if (collision.gameObject.GetComponent<FireballProjectile>() == null && collision.gameObject.GetComponent<IceProjectile>() == null)
        {
            Destroy(this.gameObject);
        }
    }
}
