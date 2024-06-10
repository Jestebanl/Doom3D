using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    private bool damagingPlayer;
    private PlayerHealth playerHealth;

    public int damageAmount = 10;
    public float timeBetweenDamage = 1.5f;


    private float damageCounter;

    // Start is called before the first frame update
    void Start()
    {
        damageCounter = timeBetweenDamage;
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (damagingPlayer)
        {
            // damage player every (timeBetweenDamage) 1.5 seconds
            if(damageCounter >= timeBetweenDamage)
            {
                // damage player
                playerHealth.DamagePlayer(damageAmount);

                // restart counter
                damageCounter = 0f;
            }

            // add to counter
            damageCounter += Time.deltaTime;
        }
        else
        {
            damageCounter = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            damageCounter = timeBetweenDamage;
            damagingPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            damagingPlayer = false;
        }
    }
}
