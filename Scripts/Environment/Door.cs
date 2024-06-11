using System;
using UnityEngine;

public class Door : MonoBehaviour
{


    public Animator doorAnim;//animacion cuando la puerta se abre
    //como las puertas se abren solo si tienes la llave de acceso correcta, hacemos un booleano para comprobarlo
    public bool requireskey;
    public bool reqRed, reqGreen, reqBlue;//hay tres puertas diferentes con tres llaves de acceso diferentes
    public bool isOpen;//booleano ppara abrir la puerta





    private void Start()
    {
        //al iniciar el programa, la puerta obviamente esta cerrada
        isOpen = false;
    }

    private void Update()
    {
        //si la puerta esta abierta:
        if (isOpen)
        {
            //se destrulle el boxcollider que envolvia a la puerta, para que el player pueda pasar a traves de ella
            Destroy(gameObject.GetComponent<BoxCollider>());
        }
    }
    //funcion que sirve para detectar al player si entra dentro del collider de la puerta y abrir la puerta si tiene la llave
    void OnTriggerEnter(Collider other)
    {
        //si lo que entra dentro del collider de la puerta tiene la tag de "player"
        if (other.CompareTag("Player"))
        {
            //si la puerta requiere una llave de acceso:
            if (requireskey)
            {
                // como hay tres llaves diferentes, tenemos que comprobar cual es la llave que tiene
                // y abrir la puerta si es la correcta
                if (reqRed && other.GetComponent<PlayerInventory>().hasRed)
                {
                    //si es la puerta roja y tiene la llave de acceso roja se inicia la animacion "openDoor"
                    doorAnim.SetTrigger("OpenDoor");
                    
                    //el boolean de esta abierta se vuelve true para eliminar el boxCollider para que el player pueda pasar
                    isOpen = true;
                    
                }

                if (reqGreen && other.GetComponent<PlayerInventory>().hasGreen)
                {
                    doorAnim.SetTrigger("OpenDoor");
                    isOpen = true;
                    
                }

                if (reqBlue && other.GetComponent<PlayerInventory>().hasBlue)
                {
                    doorAnim.SetTrigger("OpenDoor");
                    isOpen = true;
                    
                }

            }
            //Como hay puertas que no requieren llaves (las iniciales) las abrimos directamente
            else
            {
                doorAnim.SetTrigger("OpenDoor");
                isOpen = true;
                
            }
        }
    }
}