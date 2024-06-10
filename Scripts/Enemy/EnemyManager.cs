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
        gameManager = FindObjectOfType<GameManager>();
        
        playerHealth = FindObjectOfType<PlayerHealth>();
        enemiesLeft = FindObjectsOfType<Enemy>();
        allEnemiesDead = false;
        
    }
    
    void Update()
    {
        foreach (Enemy enemy in enemiesLeft)
        {
            if (enemy.estaMuerto)
            {
                allEnemiesDead = true;
                
            }
            else
            {
                allEnemiesDead = false;
            }
        }
        
        if (playerHealth.health <= 0)
        {
            gameManager.Defeat();
        }

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
