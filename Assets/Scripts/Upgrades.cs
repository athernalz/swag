using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrade", order = 51)]
public class Upgrades : ScriptableObject
{
    public string upgradeName;
    public Sprite upgradeSprite;
    public int currentUpgradeLevel;
    public float baseEffect;
    public string description;
    public Sprite icon;

    public float GetCurrentEffect()
    {
        return baseEffect * Mathf.Pow(1.25f, currentUpgradeLevel - 1);
    }

    public void Upgrade()
    {
        currentUpgradeLevel++;
    }

    public string GetDynamicDescription()
    {
        return $"{description} Current power: {GetCurrentEffect().ToString("F2")}%."; // "F2" formats to two decimal places
    }
}
