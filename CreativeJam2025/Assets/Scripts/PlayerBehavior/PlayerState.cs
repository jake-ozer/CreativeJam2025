using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerState : MonoBehaviour
{

    public enum PlayerStateEnum
    {
        Active,
        Dormant
    }

    public void ChangePlayerState(PlayerStateEnum state)
    {
        switch (state)
        {
            case PlayerStateEnum.Active:
                GetComponent<PlayerMovement>().stopMoving = false;
                GetComponent<PlayerShoot>().enabled = true;
                Camera.main.GetComponent<PlayerCamera>().enabled = true;
                break;
            case PlayerStateEnum.Dormant:
                GetComponent<PlayerMovement>().stopMoving = true;
                GetComponent<PlayerShoot>().enabled = false;
                Camera.main.GetComponent<PlayerCamera>().enabled = false;
                break;
        }
    }
}
