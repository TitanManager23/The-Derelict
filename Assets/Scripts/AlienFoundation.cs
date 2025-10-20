using UnityEngine;
using UnityEngine.AI;

public class AlienFoundation : MonoBehaviour
{
    public Transform player;          // Reference to the player
    public float chaseRange = 10f;    // Distance at which the enemy starts chasing
    public float stopDistance = 2f;   // How close the enemy gets before stopping

    private NavMeshAgent agent;
    private bool isChasing = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= chaseRange)
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
            agent.ResetPath(); // stop moving if too far
        }

        if (isChasing)
        {
            if (distance > stopDistance)
            {
                agent.SetDestination(player.position);
            }
            else
            {
                agent.ResetPath(); // stop when close enough
            }
        }
    }

    // Optional: visualize chase radius
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
