using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class UpgradesManager : MonoBehaviour
{
    public List<Upgrades> availableUpgrades; // Assign this list in the Unity Editor
    public Button[] upgradeButtons; // Assign your 3 buttons in the Unity Editor
    public TMP_Text[] upgradeNames; // Assign the corresponding Text components for names
    public TMP_Text[] upgradeDescription; // Assign the corresponding Text components for descriptions
    public Image[] upgradeIcons; // Assign the corresponding Image components for icons
    public TMP_Text[] upgradeCurrentLevel;
    public Player player;
    public GameObject disableUpgradeScreen;
    public GameObject weaponPrefab;

    private void Start()
    {
        
    }


    // Call this method when the player levels up
    public void DisplayRandomPowerups()
    {
        Time.timeScale = 0f;
        HashSet<int> selectedIndices = new HashSet<int>();

        // Randomly select 3 unique powerups
        while (selectedIndices.Count < 3)
        {
            int randomIndex = Random.Range(0, availableUpgrades.Count);
            selectedIndices.Add(randomIndex);
        }

        int buttonIndex = 0;
        foreach (int index in selectedIndices)
        {
            Upgrades upgrade = availableUpgrades[index];

            // Update button UI with powerup name, icon, and dynamic description
            upgradeNames[buttonIndex].text = upgrade.upgradeName;
            upgradeDescription[buttonIndex].text = upgrade.GetDynamicDescription();
            upgradeIcons[buttonIndex].sprite = upgrade.icon;
            upgradeCurrentLevel[buttonIndex].text = upgrade.currentUpgradeLevel.ToString();

            // Assign a listener to the button (make sure to remove old listeners first)
            upgradeButtons[buttonIndex].onClick.RemoveAllListeners();
            upgradeButtons[buttonIndex].onClick.AddListener(() => ApplyUpgrade(upgrade));

            buttonIndex++;
        }
    }

    // Implement how a powerup should be applied when a button is clicked
    // Implement how a powerup should be applied when a button is clicked
    // Implement how a powerup should be applied when a button is clicked
    void ApplyUpgrade(Upgrades upgrade)
    {
        // Example: Increment powerup level, apply effects, etc.
        upgrade.Upgrade();

        int effectToApplyRounded = Mathf.RoundToInt(upgrade.GetCurrentEffect());
        float floatGetCurrentEffect = (float)upgrade.GetCurrentEffect();

        switch (upgrade.upgradeName)
        {
            case "Health Boost":
                player.maxHP += effectToApplyRounded;
                player.currentHP += effectToApplyRounded;
                break;
            case "Speed Boost":
                float speedBoost = upgrade.GetCurrentEffect();
                player.moveSpeed += speedBoost;
                break;
            case "Scythe Size":
                UpgradesManager upgradesManager = GetComponent<UpgradesManager>();
                upgradesManager.weaponPrefab.transform.localScale = new Vector2(1+(floatGetCurrentEffect * 2), 1+ (floatGetCurrentEffect * 2));
                break;
            // Add more cases for other upgrade types as needed
            default:
                Debug.LogWarning("Unknown upgrade type: " + upgrade.upgradeName);
                break;
        }

        disableUpgradeScreen.SetActive(false);
        Time.timeScale = 1.0f;
    }



}
