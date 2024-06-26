using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class EnemyManager : MonoBehaviour
{
    
    [SerializeField]
    public GameManager gameManager;
    public List<Enemy> enemiesInTrigger = new List<Enemy>();

    private PlayerHealth playerHealth;
    
    public List<Enemy> enemiesLeft;

    
    void Start()
    {
        //buscamos al comienzo el gameManager
        gameManager = FindObjectOfType<GameManager>();
        
        //llamamos a la salud del player desde el script PlayerHealth
        playerHealth = FindObjectOfType<PlayerHealth>();

    }
    
    void Update()
    {
        //si la saud del jugador es negativa, ha muerto y aparece la escena especificada en la funcion Defeat()
        if (playerHealth.health <= 0)
        {
            gameManager.Defeat();
        }

        //Si todos los enemigos estan muertos, el player ha ganado y sale la escena de victorio
        if (enemiesLeft.Count == 0)
        {
            gameManager.Victory();
        }
    }
   //funciones para añadir o eliminar un enemigo
    public void AddEnemyInTrigger(Enemy enemy)
    {
        enemiesInTrigger.Add(enemy);
    }
    public void RemoveEnemyInTrigger(Enemy enemy)
    {
        enemiesInTrigger.Remove(enemy);
    }
    //funciones para añadir un enemigo vivo y otro para remover un enemigo con vida 0
    public void AddEnemyAlive(Enemy enemy)
    {
        enemiesLeft.Add(enemy);
    }
    public void RemoveEnemyDead(Enemy enemy)
    {
        enemiesLeft.Remove(enemy);
    }
    
    
}
