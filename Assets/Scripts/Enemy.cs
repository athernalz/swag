using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int currentHP;
    public int maxHP;
    public float moveSpeed;
    public float worthXP;
    public PlayerXPManager playerXPManager;

    public virtual void Start()
    {
        currentHP = maxHP; // Enemy starts off with the Max HP
    }

    public void GiveXPToPlayer()
    {
        PlayerXPManager playerXPManager = FindObjectOfType<PlayerXPManager>();
        playerXPManager.currentXP += worthXP;
    }

    public virtual void TakeDamage(int amount)
    {
        currentHP -= amount;
        Debug.Log(gameObject.name + " took " + amount + " damage.");

        if (currentHP <= 0)
        {
            Death();
        }
    }

    protected void Death()
    {
        GiveXPToPlayer();
        Debug.Log(gameObject.name + " died.");
        Destroy(gameObject);
    }
}