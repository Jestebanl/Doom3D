using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;


public class GameOver : MonoBehaviour
{
    [SerializeField]
    public GameManager gameManager;
    private GameObject play;
    private GameObject mainMenu;

    void Start ()
    {
        
        gameManager = FindObjectOfType<GameManager>();
        
        play = GameObject.Find("Try Again");
        Button start = play.GetComponent<Button>();
        start.onClick.AddListener(gameManager.Play);

        mainMenu = GameObject.Find("Menu");
        Button menu = mainMenu.GetComponent<Button>();
        menu.onClick.AddListener(gameManager.Menu);
    }
    
}
