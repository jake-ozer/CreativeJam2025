using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    //this script handles the shooting of fire and ice

    [SerializeField] private GameObject fireProjectile;
    [SerializeField] private GameObject iceProjectile;
    [SerializeField] private Animator staffAnim;
    [SerializeField] private float shootCooldown;
    [SerializeField] private Transform staffSpawnTransform;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private AudioClip fireballSound;
    [SerializeField] private AudioClip iceballSound;
    [SerializeField] private AudioClip chargeSound;
    private PlayerInput input;
    private float cooldownTimer = 0;

    private void Start()
    {
        input = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if (input.actions["ShootFire"].triggered && cooldownTimer < 0)
        {
            GetComponent<AudioSource>().PlayOneShot(chargeSound);
            staffAnim.SetTrigger("ShootFire");
            cooldownTimer = shootCooldown;
        }

        if (input.actions["ShootIce"].triggered && cooldownTimer < 0)
        {
            GetComponent<AudioSource>().PlayOneShot(chargeSound);
            staffAnim.SetTrigger("ShootIce");
            cooldownTimer = shootCooldown;
        }
    }

    //called by animation event
    public void ShootFireball()
    {
        GetComponent<AudioSource>().PlayOneShot(fireballSound);
        ShootProjectile(staffSpawnTransform, fireProjectile);
    }

    //called by animation event
    public void ShootIceBall()
    {
        GetComponent<AudioSource>().PlayOneShot(iceballSound);
        ShootProjectile(staffSpawnTransform, iceProjectile);
    }

    private void ShootProjectile(Transform spawnTransform, GameObject projectileObj)
    {
        GameObject projectile = Instantiate(projectileObj, spawnTransform.position, Quaternion.identity);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out RaycastHit hit, 1000f))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(1000f);
        }
        Vector3 dir = (targetPoint - spawnTransform.position).normalized;
        rb.linearVelocity = dir * projectileSpeed;

    }
}
