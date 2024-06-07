using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public Button play;

    void Start () {
        Button btn = play.GetComponent<Button>();
        btn.onClick.AddListener(OnButtonClick);
    }
    

    void OnButtonClick()
    {
        SceneManager.LoadScene(1);
    }
}
