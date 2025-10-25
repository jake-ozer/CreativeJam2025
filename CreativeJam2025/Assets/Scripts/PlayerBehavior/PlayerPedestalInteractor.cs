using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPedestalInteractor : MonoBehaviour
{
    [SerializeField] private float distance = 3f;
    [SerializeField] private PlayerInput input;

    private Camera cam;
    private Pedestal storedPedestal;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        /*if (input.actions["Interact"].WasPressedThisFrame())
        {
            Debug.Log("tried to interact");
        }*/


        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.collider.gameObject.GetComponent<Pedestal>() != null && GetComponent<PlayerOrbController>().isHoldingOrb)
            {            
                storedPedestal = hitInfo.collider.gameObject.GetComponent<Pedestal>();
                hitInfo.collider.gameObject.GetComponent<Outline>().enabled = true;

                if (input.actions["Interact"].WasPressedThisFrame())
                {
                    Debug.Log("tried to touch pedestal");
                    TransferOrbToPedestal(storedPedestal);
                }
            }
            else
            {
                if (storedPedestal != null)
                {
                    storedPedestal.gameObject.GetComponent<Outline>().enabled = false;
                }
            }
        }
    }

    private void TransferOrbToPedestal(Pedestal pedestal)
    {
        GetComponent<PlayerOrbController>().currentlyHeldOrb.gameObject.transform.parent = pedestal.transform.Find("OrbTransform");
        GetComponent<PlayerOrbController>().currentlyHeldOrb.gameObject.transform.localPosition = Vector3.zero;
        GetComponent<PlayerOrbController>().isHoldingOrb = false;
        GetComponent<PlayerOrbController>().currentlyHeldOrb = null;
    }
}
