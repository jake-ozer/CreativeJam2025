using UnityEngine;
using UnityEngine.AI;

public class RoamingMinionAI : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float minDistanceUntilAttack;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindFirstObjectByType<PlayerMovement>().gameObject;
    }

    private void Update()
    {
        if (agent != null && agent.enabled)
        {
            if ((player.transform.position - this.transform.position).magnitude <= minDistanceUntilAttack)
            {
                agent.SetDestination(player.transform.position);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(this.transform.position, minDistanceUntilAttack);
    }
}
