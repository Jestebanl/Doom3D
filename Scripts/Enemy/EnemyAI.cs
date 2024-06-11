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
            //Comprobamos si el enemigo est� en estado de agresi�n , y si es as�, el enemigo mersigue al personaje 
            if (enemyAwareness.isAggro)
            {
                enemyNavMeshAgent.SetDestination(playersTransform.position);
            }
            else
            {
                //Con esto conseguimos que si el enemigo no esta en estado de agresi�n , se quede quieto en su posici�n asignada 
                enemyNavMeshAgent.SetDestination(transform.position);
            }
        }
    }
}
