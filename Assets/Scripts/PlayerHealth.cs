using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Runtime.CompilerServices;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour


{
    public Image kat;
    public int maxHP = 100;
    private int currentHP;
    public Image hpBar;
    public TMP_Text hpText;

    void Start()
    {
        currentHP = maxHP;
    }
    public void takeDamage(int amount)
    {
        currentHP = currentHP - amount;
        Debug.Log("Player's health decreased to: " + currentHP);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                takeDamage(10);
            }

        }
    }
    void Update()
    {
        if (currentHP <= 0)
        {
            Destroy(gameObject);
            Debug.Log("dead");
            kat.gameObject.SetActive(true);
        }

        hpBar.fillAmount = (float)currentHP / 100;
        hpText.text = currentHP.ToString();

    }
}
