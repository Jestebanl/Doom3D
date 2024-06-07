using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    public void Menu()
    {
        SceneManager.LoadScene(1);
    }
    
    public void Play()
    {
        SceneManager.LoadScene(0);
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
