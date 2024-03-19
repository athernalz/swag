using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SimpleEnemy : Enemy
{
    public Image hpBarEnemy;
    public GameObject playerPrefab;
    public override void Start()
    {
        base.Start(); // Enemy.cs
        maxHP = 30;
        moveSpeed = 3.5f;
        currentHP = maxHP;
    }

    void Update()
    {
        hpBarEnemy.fillAmount = (float)currentHP / maxHP;

        // Make enemy follow player.
        if (playerPrefab != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPrefab.transform.position, moveSpeed * Time.deltaTime);
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
