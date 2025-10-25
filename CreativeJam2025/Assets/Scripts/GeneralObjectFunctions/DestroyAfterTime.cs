using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] private float destroyAfterTime;

    private void Start()
    {
        Invoke("DestroyMyself", destroyAfterTime);
    }

    private void DestroyMyself()
    {
        Destroy(this.gameObject);
    }
}
