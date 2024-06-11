using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    private bool damagingPlayer;
    private PlayerHealth playerHealth;

    public int damageAmount = 20;
    public float timeBetweenDamage = 0.5f;


    private float damageCounter;
    
    void Start()
    {
        damageCounter = timeBetweenDamage;
        playerHealth = FindObjectOfType<PlayerHealth>();//buscamos la salud del enemigo llamando al script PlayerHealth
    }
    
    void Update()
    {
        //si los elementos del mapa estan dañando al enemigo
        if (damagingPlayer)
        {
            //daña al enemigo cada 1.5 segundos
            if(damageCounter >= timeBetweenDamage)
            {
                // le quitamos vida al player mediante una funcion llamada DamageHealth()
                playerHealth.DamagePlayer(damageAmount);

                // reestablecemos el contador para que tarde otros 1.5 segundos en hacer daño
                damageCounter = 0f;
            }
            
            damageCounter += Time.deltaTime;
        }
        else
        {
            damageCounter = 0f;
        }
    }
    //Creamos una funcione para saber si el player esta chocando con una elemento del mapa que produzca daño 
    private void OnTriggerEnter(Collider other)
    {
        //si el elemento tiene como tag "player" entonces empezara el proceso de hacer daño
        if (other.CompareTag("Player"))
        {
            damageCounter = timeBetweenDamage;
            damagingPlayer = true;
        }
    }
    //esta funcion sirve para que el ambiente deje de hacer daño al player cundo no está tocando un elemento dañino del mapa
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            damagingPlayer = false;
        }
    }
}
