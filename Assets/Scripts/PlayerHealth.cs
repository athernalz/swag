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
    private bool canTakeDamage = true;
    private float damageCooldownTimer = 0f;
    private float damageCooldownDuration = 0.3f;
    public Image redFlash;
    void Start()
    {
        currentHP = maxHP;
        redFlash.enabled = false;
    }
    public void takeDamage(int amount)
    {
        if (canTakeDamage)
        {
            currentHP = currentHP - amount;
            Debug.Log("Player's health decreased to: " + currentHP);

            if (currentHP <= 0)
            {
                Death();
            }

            else
            {
                canTakeDamage = false;
                damageCooldownTimer = damageCooldownDuration;
                FlashScreenRed();
            }

        }
    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                takeDamage(10);
            }

        }
    }
    void Death()
    {
        Debug.Log("Player has died");
        kat.gameObject.SetActive(true);
        currentHP = 0;
    }
    void Update()
    {
        hpBar.fillAmount = (float)currentHP / 100;
        hpText.text = currentHP.ToString();
        if (currentHP <= 0)
        {
            Destroy(gameObject);
            return;

        }
        if (!canTakeDamage)
        {
            damageCooldownTimer -= Time.deltaTime;
            if (damageCooldownTimer <= 0f)
            {
                canTakeDamage = true;
            }

        }

    }
    public void FlashScreenRed()
    {
        // Enable the red flash image
        redFlash.enabled = true;

        // Reset the color after a short delay
        Invoke("ResetRedFlash", 0.1f); // Adjust the delay as needed
    }

    void ResetRedFlash()
    {
        // Disable the red flash image
        redFlash.enabled = false;
    }
}
