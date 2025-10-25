using UnityEngine;

public class MinionCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerHealth>() != null)
        {
            collision.gameObject.GetComponent<PlayerHealth>().LoseHeart();
            Destroy(this.gameObject.transform.root.gameObject);
        }

        if (collision.gameObject.GetComponent<FireballProjectile>() != null || collision.gameObject.GetComponent<IceProjectile>() != null)
        {
            Destroy(this.gameObject.transform.root.gameObject);
        }
    }
}
