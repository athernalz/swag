using UnityEngine;
using UnityEngine.UI;

public class AcidicSlime : Enemy
{
    public Image hpBarEnemy;
    public GameObject playerPrefab;
    Rigidbody2D rb;

    public override void Start()
    {
        base.Start();
        maxHP = 60;
        moveSpeed = 3.5f;
        currentHP = maxHP;
        worthXP = 21.5f;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        hpBarEnemy.fillAmount = (float)currentHP / maxHP;

        if (playerPrefab != null)
        {
            Vector2 moveDirection = (playerPrefab.transform.position - transform.position).normalized;
            rb.velocity = moveDirection * moveSpeed;
        }
        else
        {
            Debug.Log("Player not found");
        }
    }



/*    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount); // Call base class TakeDamage method

        // Calculate the speed increase based on the amount of damage taken
        float speedIncreaseFactor = 0.1f; // Adjust this factor as needed
        moveSpeed += amount * speedIncreaseFactor;
    }*/
}