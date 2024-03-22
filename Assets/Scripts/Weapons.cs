using UnityEngine;

public enum WeaponType
{
    Scythe,
    // Add more;
}


[System.Serializable]
public class WeaponInfo
{
    public GameObject weaponPrefab; // Reference to the weapon prefab
    public WeaponType type; // Type of the weapon
}

public class Weapons : MonoBehaviour
{
    public float speed;
    public WeaponInfo[] weapons; // Array of weapon information

    public GameObject GetWeaponPrefab(WeaponType type)
    {
        foreach (WeaponInfo weaponInfo in weapons)
        {
            if (weaponInfo.type == type)
            {
                return weaponInfo.weaponPrefab;
            }
        }
        Debug.LogError("Weapon type not found: " + type);
        return null;
    }
}
