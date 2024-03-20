using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class SimpleEnemy : Enemy
{
    public Image hpBarEnemy;
    public GameObject playerPrefab;
    Rigidbody2D rb;
    public override void Start()
    {
        base.Start(); // Enemy.cs
        maxHP = 30;
        moveSpeed = 3.5f;
        currentHP = maxHP;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        hpBarEnemy.fillAmount = (float)currentHP / maxHP;

        // Make enemy follow player.
        if (playerPrefab != null)
        {
            Vector2 moveDirection = (playerPrefab.transform.position - transform.position).normalized;
            rb.velocity = moveDirection * moveSpeed; // Set velocity for physics-based movement playerPrefab.transform.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            Debug.Log("Player not found");
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeDamage(15);
        }

    }
}
