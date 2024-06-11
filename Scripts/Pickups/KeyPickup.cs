using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    //como el player va a ir cogiendo las llaves de acceso para las puertas
    // tenemos que hacer el código para añadirlas a su invertario y destruirlas
    public bool isRedkey, isBlueKey, isGreenKey;
    
    //funcion para comprobar que algo esta chocando con la llave de acceso
    void OnTriggerEnter(Collider other)
    {
        //si ese elemento es el player
        if (other.CompareTag("Player"))
        {
            //dependiendo de la llave que sea, se añadira una u otra al inventario del player
            if (isRedkey)
            {
                other.GetComponent<PlayerInventory>().hasRed = true;
                //además se actualizara el canvas donde aparece el estado del player para que aparezca la llave cogida
                CanvasManager.Instance.UpdateKeys("red");
            }

            if (isBlueKey)
            {
                other.GetComponent<PlayerInventory>().hasBlue = true;
                CanvasManager.Instance.UpdateKeys("blue");
            }

            if (isGreenKey)
            {
                other.GetComponent<PlayerInventory>().hasGreen = true;
                CanvasManager.Instance.UpdateKeys("green");
            }
            //destruimos la llava para que no pueda cogerla dos veces
            Destroy(gameObject);
        }
    }


}
