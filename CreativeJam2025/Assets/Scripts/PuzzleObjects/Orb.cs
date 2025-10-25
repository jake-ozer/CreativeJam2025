using UnityEngine;

public class Orb : MonoBehaviour
{
    private bool active = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerOrbController>() != null && !other.GetComponent<PlayerOrbController>().isHoldingOrb && active)
        {
            //pick up orb
            other.GetComponent<PlayerOrbController>().isHoldingOrb = true;
            other.GetComponent<PlayerOrbController>().currentlyHeldOrb = this;
            active = false;
            this.gameObject.transform.parent = Camera.main.transform.Find("OrbHoldTransform");
            this.gameObject.transform.localPosition = Vector3.zero;
        }
    }


}
