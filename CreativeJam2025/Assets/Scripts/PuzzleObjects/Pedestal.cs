using UnityEngine;

public class Pedestal : MonoBehaviour
{
    public Orb pedestalOrb;


    public bool IsCorrect()
    {
        return pedestalOrb.gameObject.tag == this.gameObject.tag;
    }

}
