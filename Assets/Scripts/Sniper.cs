using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Sniper : Enemy
{
    public Image hpBarEnemy;
    public GameObject SniperWeaponAnchorPoint;
    public GameObject playerObject;
    private bool isAggressive;
    public LineRenderer lineRenderer;

    public override void Start()
    {
        base.Start();
        maxHP = 80;
        moveSpeed = 0;
        currentHP = maxHP;
        worthXP = 35;
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            isAggressive = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            isAggressive = false;
        }

        if (isAggressive)
        {
            RotateWeapon();
            Debug.Log("Sniper is aggressive.");
            AimAtPlayer();
        }
        else
        {
            Debug.Log("Sniper is not aggressive.");
        }
    }

    void AimAtPlayer()
    {
        lineRenderer.SetPosition(0, playerObject.transform.position);
        lineRenderer.SetPosition(1, SniperWeaponAnchorPoint.transform.position);
    }

    private void RotateWeapon()
    {
        Vector2 direction = playerObject.transform.position - SniperWeaponAnchorPoint.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        SniperWeaponAnchorPoint.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

}