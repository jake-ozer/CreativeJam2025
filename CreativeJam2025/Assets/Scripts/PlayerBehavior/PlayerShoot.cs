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
            staffAnim.SetTrigger("ShootFire");
            cooldownTimer = shootCooldown;
        }

        if (input.actions["ShootIce"].triggered && cooldownTimer < 0)
        {
            staffAnim.SetTrigger("ShootIce");
            cooldownTimer = shootCooldown;
        }
    }

    //called by animation event
    public void ShootFireball()
    {
        ShootProjectile(staffSpawnTransform, fireProjectile);
    }

    //called by animation event
    public void ShootIceBall()
    {
        ShootProjectile(staffSpawnTransform, iceProjectile);
    }

    private void ShootProjectile(Transform spawnTransform, GameObject projectileObj)
    {
        GameObject projectile = Instantiate(projectileObj, spawnTransform.position, Quaternion.identity);
        //set direction to where the player is looking
        Vector3 dir = Camera.main.transform.forward;
        projectile.GetComponent<Rigidbody>().linearVelocity = dir * projectileSpeed;

    }
}
