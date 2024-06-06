using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class CanvasManager : MonoBehaviour
{
    public TextMeshProUGUI health;
    public TextMeshProUGUI armor;
    public TextMeshProUGUI ammo;

    public Image healthIndicator;

    public Sprite health1;  //healthy
    public Sprite health2;  
    public Sprite health3;  
    public Sprite health4;  //dead

    public GameObject redKey;
    public GameObject blueKey;
    public GameObject greenKey;

    public Animator reloadAnim;

    private static CanvasManager _instance;
    public static CanvasManager Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        reloadAnim = GetComponentInChildren<Animator>();
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    

    //methods to update our values

    public void UpdateHealth(int healthValue)
    {
        health.text = healthValue.ToString() + "%";
        UpdateHealthIndicator(healthValue);
    }
    public void UpdateArmor(int armorValue)
    {
        armor.text = (armorValue*2).ToString() + "%";
    }
    public void UpdateAmmo(int ammoValue)
    {
        ammo.text = ammoValue.ToString();
    }

    public void Reload()
    {
        reloadAnim.Play("Base Layer.GunReload", 0, 0);
    }


    public void UpdateHealthIndicator(int healthValue)
    {
        if (healthValue >= 66.6)
        {
            healthIndicator.sprite = health1; //healthy
        }
        else if (healthValue < 66.6 && healthValue >= 33.3)
        {
            healthIndicator.sprite = health2; 
        }
        else if (healthValue < 33.3 && healthValue > 0)
        {
            healthIndicator.sprite = health3; 
        }
        else
        {
            healthIndicator.sprite = health4; //dead
        }
    }

    public void UpdateKeys(string keyColor)
    {
        if (keyColor == "red")
        {
            redKey.SetActive(true);
        }
        if (keyColor == "blue")
        {
            blueKey.SetActive(true);
        }
        if (keyColor == "green")
        {
            greenKey.SetActive(true);
        }


    }

    public void ClearKeys()
    {
        redKey.SetActive(false);
        blueKey.SetActive(false);
        greenKey.SetActive(false);

    }

}
