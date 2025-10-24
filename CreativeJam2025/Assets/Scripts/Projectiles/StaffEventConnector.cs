using UnityEngine;

public class StaffEventConnector : MonoBehaviour
{
    [SerializeField] private PlayerShoot playerShoot;

    public void ShootFireBall()
    {
        playerShoot.ShootFireball();
    }

    public void ShootIceBall()
    {
        playerShoot.ShootIceBall();
    }
}
