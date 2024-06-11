using UnityEngine;

public class Gun : MonoBehaviour
{

    public float range = 20f;
    public float verticalRange = 20f;
    public float gunShotRadius = 20f;

    public float bigDamage = 2f;
    public float smallDamage = 1f;

    public float fireRate = 5f;
    private float nextTimeToFire;

    public int ammo;
    public int maxAmmo;


    public LayerMask raycastLayerMask;

    public LayerMask enemyLayerMask;

    private BoxCollider gunTrigger;
    public EnemyManager enemyManager;



    void Start()
    {
        gunTrigger = GetComponent<BoxCollider>();
        gunTrigger.size = new Vector3(1, verticalRange, range);
        gunTrigger.center = new Vector3(0, 0, range * 0.5f);

        ammo = 5;
        CanvasManager.Instance.UpdateAmmo(ammo);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextTimeToFire)
        {
            Fire();
        }
    }

    void Fire()
    {
        // Si tiene municion
        if(ammo > 0)
        {
            // rango simulado de tiro
            Collider[] enemyColliders;
            enemyColliders = Physics.OverlapSphere(transform.position, gunShotRadius, enemyLayerMask);

            //alert any  enemy in earshot
            foreach (var enemyCollider in enemyColliders)
            {
                enemyCollider.GetComponent<EnemyAwareness>().isAggro = true;
            }

            //play test audio 
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().Play();
            //damage enemies
            foreach (var enemy in enemyManager.enemiesInTrigger)
            {
            
                //get direction to enemy
                var dir = enemy.transform.position - transform.position;

                RaycastHit hit;
                if (Physics.Raycast(transform.position, dir, out hit, range * 1.5f, raycastLayerMask))
                {
                
                    if (hit.transform == enemy.transform)
                    {
                        //range check
                        float dist = Vector3.Distance(enemy.transform.position, transform.position);
                        if (dist > range * 0.5f)
                        {
                            //damage enemy small
                            enemy.TakeDamage(smallDamage);
                        }
                        else
                        {
                            //damage enemy big
                            enemy.TakeDamage(bigDamage);
                        }
                    }
                
                }
            }
           // reset timer 
            nextTimeToFire = Time.time + fireRate;

            // deduct 1 ammo
            ammo--;

            CanvasManager.Instance.Reload();
            CanvasManager.Instance.UpdateAmmo(ammo);
        }
    }

    public void GiveAmmo(int amount)
    {
        if (ammo < maxAmmo)
        {
            ammo += amount;
            
        }
       
        if(ammo > maxAmmo)
        {
            ammo = maxAmmo;
        }

        CanvasManager.Instance.UpdateAmmo(ammo);
    }


    private void OnTriggerEnter(Collider other)
    {
        // agregar enemigo potencial para disparar
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy)
        {
            enemyManager.AddEnemyInTrigger(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //eliminamos enemigo potencial para disparar
        Enemy enemy = other.transform.GetComponent<Enemy>();

        if (enemy)
        {
            enemyManager.RemoveEnemyInTrigger(enemy);
        }
    }



}
