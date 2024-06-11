using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth;
    public int health;

    public int maxArmor;
    public int armor;
    // Start is called before the first frame update
    void Start()
    {
        //al empezar el juego, el player empieza con la salud máxima y con la armadura a 0
        health = maxHealth;
        armor = 0;
        //actualizamos en el canvas del estado del player para que muestre la vida y armadura actual
        CanvasManager.Instance.UpdateHealth(health);
        CanvasManager.Instance.UpdateArmor(armor);
    }
    //cuando el enemgio recibe daño , se usa esta funcion para comprobar la armadura y l vida que tenga
    public void DamagePlayer(int damage)
    {
        //si tiene 
        if (armor > 0)
        {
            if (armor >= damage)
            {
                armor -= damage;
            }
            else if (armor < damage)
            {
                int remainingDamage;

                remainingDamage = damage - armor;

                armor = 0;

                health -= remainingDamage;
            }
        }
        else
        {
            health -= damage;
        }
        if (health <= 0) //Si el player esta muerto
        {
            Debug.Log("Player died");

            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
        }

        CanvasManager.Instance.UpdateHealth(health);
        CanvasManager.Instance.UpdateArmor(armor);
    }

    public void GiveHealth(int amount)
    {
        if (health < maxHealth)
        {
            health += amount;
            
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        CanvasManager.Instance.UpdateHealth(health);
    }

    public void GiveArmor(int amount)
    {
        if (armor < maxArmor)
        {
            armor += amount;
            
        }

        if (armor > maxArmor)
        {
            armor = maxArmor;
        }

        CanvasManager.Instance.UpdateArmor(armor);
    }
    
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyAttack"))
        {
            DamagePlayer(30);
            Destroy(other);
        }
    }
    */

}
