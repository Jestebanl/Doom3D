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
        
        estaMuerto = false;
    }

    void Update()
    {
        // beginning of update set the animations rotation
        spriteAnim.SetFloat("spriteRot", angleToPlayer.lastIndex);

        if (enemyHealth <= 0)
        {
            enemyManager.RemoveEnemy(this);
            estaMuerto = true;
            spriteAnim.SetBool("estaMuerto", true);
            
        }

        // any animations we call will have updated index
    }

    public void TakeDamage(float damage)
    {
        Instantiate(gunHitEffect, transform.position, Quaternion.identity);
        enemyHealth -= damage;
        
    }
}
