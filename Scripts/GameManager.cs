using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    private PlayerHealth playerHealth;
    
    public bool allEnemiesDead;
    public Enemy[] enemiesLeft;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        
        enemiesLeft = GetComponents<Enemy>();
        allEnemiesDead = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Enemy enemy in enemiesLeft)
        {
            if (enemy.IsUnityNull())
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
            SceneManager.LoadScene(2);
        }

        if (allEnemiesDead)
        {
            SceneManager.LoadScene(3);
        }
    }
    
    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}
