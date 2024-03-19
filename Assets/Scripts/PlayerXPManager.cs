using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerXPManager : MonoBehaviour
{
    public Image xpBar;
    public float currentXP;
    public float maxXP;
    public TMP_Text xpText;
    public TMP_Text levelText;
    public int currentLevel;
    public Canvas upgradeScreen;
    public UpgradesManager upgradesManager;
    // Start is called before the first frame update
    void Start()
    {
        currentXP = 0;
        maxXP = 100;
        upgradeScreen.enabled = false;
        upgradeScreen.gameObject.SetActive(false);
    }


    void Update()
    {
        xpBar.fillAmount = currentXP / maxXP;
        xpText.text = $"EXP: {((currentXP / maxXP) * 100f):F1}%";
        levelText.text = currentLevel.ToString();

        // Level up if XP reaches or exceeds maximum
        if (currentXP >= maxXP || xpText.text == "EXP: 100.0%")
        {
            levelUp();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            addXP(50);
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            addXP(8.33f);
        }
    }


    void addXP(float amount) 
    {
        currentXP += amount;
    }

    void levelUp()
    {
        showUpgradeOptions();
        upgradesManager.DisplayRandomPowerups();
        currentLevel++;
        currentXP -= maxXP; // Deduct the excess XP
        maxXP *= 1.5f;
        Debug.Log("Leveled up! Your level is now: " + currentLevel);
    }


    void showUpgradeOptions()
    {
        upgradeScreen.enabled = true;
        upgradeScreen.gameObject.SetActive(true);
    }
    
}
