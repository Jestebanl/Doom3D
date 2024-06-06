using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    private Enemy enemy;
    
    private Transform player;
    private PlayerHealth playerHealth;
    
    public float attackRadius = 10f;
    
    [SerializeField]
    private float enemyAttackInterval = 1.5f;
    
    [SerializeField]
    private float attackCooldown;

    [SerializeField]
    private GameObject enemyAttackPrefab;

    private EnemyAwareness aggro;
    
    //private float bulletSpeed = 3f;
    
    //private Vector3 targetPos;
    //private Vector3 movementVector;
    
    public float timeBetweenDealingDamage = 1.5f;


    private float damageCounter;
    private bool enemyDamagingPlayer;
    
    
    void Start()
    {
        damageCounter = timeBetweenDealingDamage;
        attackCooldown = enemyAttackInterval;
        player = FindObjectOfType<PlayerMove>().transform;
        playerHealth = FindObjectOfType<PlayerHealth>();
        enemyDamagingPlayer = false;
        enemy = GetComponent<Enemy>();
    }

    void Update()
    {
        // Get target position and Direction
        //targetPos = new Vector3(player.position.x, transform.position.y, player.position.z);
        
        attackCooldown = attackCooldown - Time.deltaTime;
        
        var dist = Vector3.Distance(player.position, transform.position);
        
        if (dist < attackRadius && attackCooldown < 0f && !enemy.estaMuerto && aggro.isAggro)
        {
            EnemyAttacking();
        }
        
        if (enemyDamagingPlayer)
        {
            // damage player every (timeBetweenDamage) 1.5 seconds
            if(damageCounter >= timeBetweenDealingDamage)
            {
                // damage player
                playerHealth.DamagePlayer(30);

                // restart counter
                damageCounter = 0f;
            }

            // add to counter
            damageCounter += Time.deltaTime;
        }
    }

    private void EnemyAttacking()
    {
        attackCooldown = enemyAttackInterval;
        Enemy enemy = GetComponent<Enemy>();
        
        GameObject disparoEnemigoInstancia = Instantiate(enemyAttackPrefab);
        disparoEnemigoInstancia.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y, enemy.transform.position.z);
        

        //movementVector = (targetPos * bulletSpeed);
        //disparoEnemigoInstancia.GetComponent<Rigidbody>().MovePosition(targetPos);
        

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            damageCounter = timeBetweenDealingDamage;
            enemyDamagingPlayer = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            enemyDamagingPlayer = false;
        }
    }

    
}
