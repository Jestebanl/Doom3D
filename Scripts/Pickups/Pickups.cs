using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public bool isBigArmor;
    public bool isSmallArmor;
    public bool isBigMedkit;
    public bool isSmallMedkit;
    public bool isBigAmmo;
    public bool isSmallAmmo;

    private Transform player;
    private PlayerHealth playerHealth;
    private Gun playerAmmo;

    private void Start()
    {
        player = FindObjectOfType<PlayerMove>().transform;
        playerHealth = FindObjectOfType<PlayerHealth>();
        playerAmmo = FindObjectOfType<Gun>();
    }

    private void Update()
    {
        transform.LookAt(player);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isBigArmor)
            {
                playerHealth.GiveArmor(10);
            }
            if (isSmallArmor)
            {
                playerHealth.GiveArmor(5);
            }

            if (isBigMedkit)
            {
                playerHealth.GiveHealth(30);
            }
            if (isSmallMedkit)
            {
                playerHealth.GiveHealth(10);
            }

            if (isBigAmmo)
            {
                playerAmmo.GiveAmmo(10);
            }
            if (isSmallAmmo)
            {
                playerAmmo.GiveAmmo(5);
            }

            Destroy(gameObject);
        }
    }
}