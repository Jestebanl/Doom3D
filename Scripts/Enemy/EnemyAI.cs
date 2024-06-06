using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private EnemyAwareness enemyAwareness;
    private Transform playersTransform;
    private NavMeshAgent enemyNavMeshAgent;
    private Enemy enemy;


    private void Start()
    {
        enemyAwareness = GetComponent<EnemyAwareness>();
        playersTransform = FindObjectOfType<PlayerMove>().transform;
        enemyNavMeshAgent = GetComponent<NavMeshAgent>();
        enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        if (!enemy.estaMuerto)
        {
            if (enemyAwareness.isAggro)
            {
                enemyNavMeshAgent.SetDestination(playersTransform.position);
            }
            else
            {
                enemyNavMeshAgent.SetDestination(transform.position);
            }
        }
    }
}
