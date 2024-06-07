using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    public GameManager gameManager;
    public Button play;

    void Start ()
    {
        gameManager = FindObjectOfType<GameManager>();
        Button btn = play.GetComponent<Button>();
        btn.onClick.AddListener(gameManager.Play);
    }
    
}
