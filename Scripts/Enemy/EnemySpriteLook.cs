using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpriteLook : MonoBehaviour
{

    private Transform target;
    public bool canLookVertically;
    private Enemy enemy;
    

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerMove>().transform;
        enemy = GetComponentInParent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!enemy.estaMuerto)
        {
            if (canLookVertically)
            {
                transform.LookAt(target);
            }
            else
            {
                Vector3 modifiedTarget = target.position;
                modifiedTarget.y =transform.position.y;

                transform.LookAt(modifiedTarget);
            }
        }
    }
}
