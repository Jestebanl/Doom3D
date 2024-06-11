using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyManager enemyManager;
    private Animator spriteAnim;
    private AngleToPlayer angleToPlayer;
    
    private float enemyHealth = 2f;
    public bool estaMuerto;
    

    public GameObject gunHitEffect;


    private void Start()
    {
        spriteAnim = GetComponentInChildren<Animator>();
        angleToPlayer = GetComponent<AngleToPlayer>();

        enemyManager = FindObjectOfType<EnemyManager>(); // we can do this because there's only 1 in the scene
        
        enemyManager.AddEnemyAlive(this);
        estaMuerto = false;
    }

    void Update()
    {
        //el comienzo del update setea la animacion de rotacion
        spriteAnim.SetFloat("spriteRot", angleToPlayer.lastIndex);
         //Comprobamos si la salud del enemigo es igual o inferior a 0 para eliminarlo de la scena
        if (enemyHealth <= 0)
        {
            enemyManager.RemoveEnemy(this);
            estaMuerto = true;
            spriteAnim.SetBool("estaMuerto", true);//le damos la animacion de muerte poniendo a true el boolean de muerto
            
            enemyManager.RemoveEnemyDead(this);

        }
        
    }
    //Esta funcion esta diseñada para manejar el daño recibido en el enemigo
    public void TakeDamage(float damage)
    {
        //instanciamos un prefab(gunHitEffect) en la posicion exacta del enemigo, sin rotacion(Quaternion.identity)
        Instantiate(gunHitEffect, transform.position, Quaternion.identity);
        enemyHealth -= damage;
        
    }
}
