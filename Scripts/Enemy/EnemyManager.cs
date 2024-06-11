using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class EnemyManager : MonoBehaviour
{
    
    [SerializeField]
    public GameManager gameManager;
    public List<Enemy> enemiesInTrigger = new List<Enemy>();

    private PlayerHealth playerHealth;
    
    public bool allEnemiesDead;
    public Enemy[] enemiesLeft;
    
    void Start()
    {
        //buscamos al comienzo el gameManager
        gameManager = FindObjectOfType<GameManager>();
        //llamamos a la salud del player desde el script PlayerHealth
        playerHealth = FindObjectOfType<PlayerHealth>();
        enemiesLeft = FindObjectsOfType<Enemy>();//total de enemigos a vencer
        allEnemiesDead = true;
        
    }
    
    void Update()
    {
        foreach (Enemy enemy in enemiesLeft)
        {
            if (!enemy.estaMuerto)
            {
                allEnemiesDead = false;
            }
        }
        //si la saud del jugador es negativa, ha muerto y aparece la escena especificada en la funcion Defeat()
        if (playerHealth.health <= 0)
        {
            gameManager.Defeat();
        }
        //Si todos los enemigos estan muertos, el player ha ganado y sale la escena de victorio
        if (allEnemiesDead)
        {
            gameManager.Victory();
        }
    }

    public void AddEnemy(Enemy enemy)
    {
        enemiesInTrigger.Add(enemy);
    }
    public void RemoveEnemy(Enemy enemy)
    {
        enemiesInTrigger.Remove(enemy);
    }
}
