using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrade", order = 51)]
public class Upgrades : ScriptableObject
{

    public string upgradeName;
    public float baseEffect;
    public string description;
    public Sprite icon;
    public GameObject weaponPrefab;

    [System.NonSerialized] // Using this so stats don't save.
    public int currentUpgradeLevel;

    // Define a constant increase per level
    private const float IncreasePerLevel = 0.2f;

    public float GetCurrentEffect()
    {
        return baseEffect + (baseEffect * IncreasePerLevel * (currentUpgradeLevel - 1));
    }

    public void Upgrade()
    {
        currentUpgradeLevel++;
    }

    public string GetDynamicDescription()
    {
        float nextLevelEffect = baseEffect + (baseEffect * IncreasePerLevel * currentUpgradeLevel);
        return $"{description} POWER: {nextLevelEffect.ToString("F2")}.";
    }
}
