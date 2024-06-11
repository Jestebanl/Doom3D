using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    //creamos funciones que servirán para cargar las distintas escenas del juego,como el menu principal o el mapa
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Defeat()
    {
        SceneManager.LoadScene(2);
    }

    public void Victory()
    {
        SceneManager.LoadScene(3);
    }
}
