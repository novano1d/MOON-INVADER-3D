using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    public TMP_Text healthTxt;
    public TMP_Text ammoTxt;
    public int health = 100;
    public int ammo = 10;

    // Update is called once per frame
    void Update()
    {
        healthTxt.text = "Health: " + health;
        ammoTxt.text = "Ammo: " + ammo;
        if (health <= 0)
        {
            SceneManager.LoadScene(0); //go to main menu on death
        }
    }
}
