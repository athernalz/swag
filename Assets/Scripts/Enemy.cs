using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int currentHP;
    public int maxHP;
    public float moveSpeed;
    public float worthXP;
    public Player player;
    private Color originalColor; // Store the original color of the enemy
    private SpriteRenderer spriteRenderer;

    public virtual void Start()
    {
        currentHP = maxHP; // Enemy starts off with the Max HP
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    public void GiveXPToPlayer()
    {
        Player playerXPManager = FindObjectOfType<Player>();
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
        if (CameraShake.Instance != null)
        {
            CameraShake.Instance.ShakeCamera(0.5f, Random.Range(1f, 2f), Random.Range(0.4f, 0.57f));

            Debug.Log("shake pls");
        }
        GiveXPToPlayer();
        Debug.Log(gameObject.name + " died.");
        Destroy(gameObject);
    }
}