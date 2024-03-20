using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int currentHP;
    public int maxHP;
    public float moveSpeed = 2.5f;
    public float worthXP = 21.5f;
    public PlayerXPManager playerXPManager;

    public virtual void Start()
    {
        maxHP = 100;
        currentHP = maxHP; // Enemy starts off with the Max HP
    }

    public void GiveXPToPlayer()
    {
        PlayerXPManager playerXPManager = FindObjectOfType<PlayerXPManager>();
        playerXPManager.currentXP += worthXP;
    }

    public void TakeDamage(int amount)
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
