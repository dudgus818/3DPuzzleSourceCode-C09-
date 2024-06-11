using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent navMeshAgent;

    public void Initialize(Transform playerTransform)
    {
        player = playerTransform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (navMeshAgent != null && player != null)
        {
            navMeshAgent.SetDestination(player.position);
        }
    }

    private void Update()
    {
        if (navMeshAgent != null && player != null)
        {
            navMeshAgent.SetDestination(player.position);
        }
    }

    public void SetSpeed(float speed)
    {
        if (navMeshAgent != null)
        {
            navMeshAgent.speed = speed;
        }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
