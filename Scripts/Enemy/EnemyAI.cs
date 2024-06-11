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
        //Comprobamos si el enemigo esta muerto (Si el enemigo esta muerto no hace nada )
        if (!enemy.estaMuerto)
        {
            //Comprobamos si el enemigo está en estado de agresión , y si es así, el enemigo mersigue al personaje 
            if (enemyAwareness.isAggro)
            {
                enemyNavMeshAgent.SetDestination(playersTransform.position);
            }
            else
            {
                //Con esto conseguimos que si el enemigo no esta en estado de agresión , se quede quieto en su posición asignada 
                enemyNavMeshAgent.SetDestination(transform.position);
            }
        }
    }
}
