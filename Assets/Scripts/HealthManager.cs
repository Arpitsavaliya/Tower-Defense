using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (healthAmount <= 0)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            TakeDamage(5);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Heal(5);
        }
    }
    public void TakeDamage(float dmg)
    {
        healthAmount -= dmg;
        healthBar.fillAmount = healthAmount / 100f;
    }
    public void Heal(float healAmt)
    {
        healthAmount += healAmt;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        healthBar.fillAmount = healthAmount / 100f;
    }
}
