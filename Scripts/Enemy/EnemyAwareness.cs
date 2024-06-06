using UnityEngine;

public class EnemyAwareness : MonoBehaviour
{
    public float awarenessRadius = 20f;
    public bool isAggro;

    private Transform playersTransform;

    private void Start()
    {
        playersTransform = FindObjectOfType<PlayerMove>().transform;
    }


    private void Update()
    {
        var dist = Vector3.Distance(playersTransform.position, playersTransform.position);

        if (dist < awarenessRadius)
        {
            isAggro = true;
        }


       
    }



}
