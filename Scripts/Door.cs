using System;
using UnityEngine;

public class Door : MonoBehaviour
{


    public Animator doorAnim;

    public bool requireskey;
    public bool reqRed, reqGreen, reqBlue;
    public bool isOpen;



    public GameObject areaToSpawn;


    private void Start()
    {
        isOpen = false;
    }

    private void Update()
    {
        if (isOpen)
        {
            Destroy(gameObject.GetComponent<BoxCollider>());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            if (requireskey)
            {
                if (reqRed && other.GetComponent<PlayerInventory>().hasRed)
                {
                    doorAnim.SetTrigger("OpenDoor");
                    isOpen = true;
                    areaToSpawn.SetActive(true);
                }

                if (reqGreen && other.GetComponent<PlayerInventory>().hasGreen)
                {
                    doorAnim.SetTrigger("OpenDoor");
                    isOpen = true;
                    areaToSpawn.SetActive(true);
                }

                if (reqBlue && other.GetComponent<PlayerInventory>().hasBlue)
                {
                    doorAnim.SetTrigger("OpenDoor");
                    isOpen = true;
                    areaToSpawn.SetActive(true);
                }

            }
            else
            {
                doorAnim.SetTrigger("OpenDoor");
                isOpen = true;
                areaToSpawn.SetActive(true);
            }
        }
    }
}