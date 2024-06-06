using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Transform player;
    private PlayerHealth playerHealth;


    private float bulletSpeed = 10f;

    private Vector3 targetPos;
    private Vector3 targetDir;
    private Vector3 movementVector;

    private float angle;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMove>().transform;
        playerHealth = FindObjectOfType<PlayerHealth>();
        targetPos = new Vector3(player.position.x, transform.position.y, player.position.z);
        targetDir = targetPos - transform.position;

        // Get Angle
        angle = Vector3.SignedAngle(targetDir, transform.forward, Vector3.up);

        MoveToPlayer(angle);

    }

    private void MoveToPlayer(float angle)
    {
        if (angle > -22.5f && angle < 22.6f)
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(angle / bulletSpeed, 0, bulletSpeed);
        if (angle >= 22.5f && angle < 67.5f)
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(-angle / bulletSpeed * 1.5f, 0, angle / bulletSpeed * 1.5f);
        if (angle >= 67.5f && angle < 112.5f)
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(-bulletSpeed, 0, bulletSpeed / angle);
        if (angle >= 112.5f && angle < 157.5f)
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(-angle / bulletSpeed * 1.5f, 0, -angle / bulletSpeed * 1.5f);



        // back
        if (angle <= -157.5f || angle >= 157.5f)
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(bulletSpeed / angle, 0, -bulletSpeed);
        if (angle >= -157.4f && angle < -112.5f)
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(-angle / bulletSpeed * 1.5f, 0, angle / bulletSpeed * 1.5f);
        if (angle >= -112.5f && angle < -67.5f)
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(bulletSpeed, 0, -bulletSpeed / angle);
        if (angle >= -67.5f && angle <= -22.5f)
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(-angle / bulletSpeed * 1.5f, 0, -angle / bulletSpeed * 1.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealth.DamagePlayer(30);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Enemy") || other.CompareTag("Gun") || other.CompareTag("DamageFloor"))
        {

        }
        else
        {
            Destroy(gameObject);
        }

    }
}