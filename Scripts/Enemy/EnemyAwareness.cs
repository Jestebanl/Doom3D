using UnityEngine;

public class EnemyAwareness : MonoBehaviour
{
    public float awarenessRadius = 15f;
    public bool isAggro;

    private Transform playersTransform;

    private void Start()
    {
        playersTransform = FindObjectOfType<PlayerMove>().transform;
        awarenessRadius = 15f;
    }


    private void Update()
    {
        var dist = Vector3.Distance(playersTransform.position, transform.position);

        
        if (dist < awarenessRadius)
        {
            isAggro = true;
        }


       
    }



}
