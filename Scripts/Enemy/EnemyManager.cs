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
        gameManager = FindObjectOfType<GameManager>();
        
        playerHealth = FindObjectOfType<PlayerHealth>();

    }
    
    void Update()
    {
        
        if (playerHealth.health <= 0)
        {
            gameManager.Defeat();
        }

        if (enemiesLeft.Count == 0)
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
    
    public void AddEnemyAlive(Enemy enemy)
    {
        enemiesLeft.Add(enemy);
    }
    public void RemoveEnemyDead(Enemy enemy)
    {
        enemiesLeft.Remove(enemy);
    }
    
    
}
