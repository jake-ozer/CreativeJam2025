using UnityEngine;

public class Orb : MonoBehaviour
{
    private bool active = true;
    public GameObject orbCanvas;

    private void Start()
    {
        orbCanvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerOrbController>() != null && !other.GetComponent<PlayerOrbController>().isHoldingOrb && active)
        {
            //pick up orb
            orbCanvas.SetActive(true);
            other.GetComponent<PlayerOrbController>().isHoldingOrb = true;
            other.GetComponent<PlayerOrbController>().currentlyHeldOrb = this;
            active = false;
            this.gameObject.transform.parent = Camera.main.transform.Find("OrbHoldTransform");
            this.gameObject.transform.localPosition = Vector3.zero;
        }
    }

    private void Update()
    {
        if (!active && Input.GetKey("f")) //destroy orb if we picked it up and dont want it
        {
            FindFirstObjectByType<PlayerOrbController>().isHoldingOrb = false;
            Destroy(this.gameObject);
        }
    }

}
