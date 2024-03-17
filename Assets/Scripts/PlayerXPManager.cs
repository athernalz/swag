using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerXPManager : MonoBehaviour
{
    public Image xpBar;
    public float currentXP;
    public float maxXP;
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
        xpBar.fillAmount = currentXP;

        if (currentXP >= maxXP) 
        {
            levelUp();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            addXP(50);
        }
        xpBar.fillAmount = currentXP / maxXP;
    }

    void addXP(int amount) 
    {
        currentXP += amount;
    }

    void levelUp()
    {
        showUpgradeOptions();
        upgradesManager.DisplayRandomPowerups();
        currentLevel++;
        maxXP *= 1.5f;
        currentXP = 0;
        Debug.Log("Leveled up! Your level is now: " + currentLevel);
    }

    void showUpgradeOptions()
    {
        upgradeScreen.enabled = true;
        upgradeScreen.gameObject.SetActive(true);
    }
    
}
