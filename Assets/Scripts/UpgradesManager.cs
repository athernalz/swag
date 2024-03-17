using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradesManager : MonoBehaviour
{
    public List<Upgrades> availableUpgrades; // Assign this list in the Unity Editor
    public Button[] upgradeButtons; // Assign your 3 buttons in the Unity Editor
    public TMP_Text[] upgradeNames; // Assign the corresponding Text components for names
    public TMP_Text[] upgradeDescription; // Assign the corresponding Text components for descriptions
    public Image[] upgradeIcons; // Assign the corresponding Image components for icons

    // Call this method when the player levels up
    public void DisplayRandomPowerups()
    {
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

            // Assign a listener to the button (make sure to remove old listeners first)
            upgradeButtons[buttonIndex].onClick.RemoveAllListeners();
            upgradeButtons[buttonIndex].onClick.AddListener(() => ApplyPowerup(upgrade));

            buttonIndex++;
        }
    }

    // Implement how a powerup should be applied when a button is clicked
    void ApplyPowerup(Upgrades upgrade)
    {
        // Example: Increment powerup level, apply effects, etc.
        upgrade.Upgrade();
        // You might want to hide the powerup selection UI here or do other logic
    }
}
