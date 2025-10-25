using UnityEngine;

public class CyclopsThrowActivator : MonoBehaviour
{
    [SerializeField] private GameObject mudPrefab;
    [SerializeField] private Transform mudSpawnTransform;
    [SerializeField] private float projectileSpeed = 6f;

    public void ThrowMud()
    {
        GameObject projectile = Instantiate(mudPrefab, mudSpawnTransform.position, Quaternion.identity);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        Vector3 targetPoint = FindFirstObjectByType<PlayerMovement>().transform.position;
        Vector3 dir = (targetPoint - mudSpawnTransform.position).normalized;
        rb.linearVelocity = dir * projectileSpeed;
    }
}
