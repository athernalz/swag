using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Sniper : Enemy
{
    public Image hpBarEnemy;
    public GameObject SniperWeaponAnchorPoint;
    public GameObject playerObject;
    public LayerMask playerLayerMask;
    public LineRenderer laser;
    public float laserWidth = 0.1f;
    public Color laserColor = Color.red;
    private bool isAggressive = false;
    private Coroutine modeSwitchCoroutine;
    private bool canDealDamage = false;
    private bool stopLaser = false;
    public float damageAmount = 50f;
    public float damageDelay = 1f;

    private void  Start()
    {
        base.Start();
        maxHP = 20;
        moveSpeed = 0;
        currentHP = maxHP;
        worthXP = 35;
        playerObject = GameObject.FindGameObjectWithTag("Player");

        laser.startWidth = laserWidth;
        laser.endWidth = laserWidth;
        laser.startColor = laserColor;
        laser.endColor = laserColor;
        laser.enabled = false;

        modeSwitchCoroutine = StartCoroutine(SwitchModeRandomly());
    }

    private IEnumerator SwitchModeRandomly()
    {
        while (true)
        {
            isAggressive = !isAggressive;
            stopLaser = false;

            Debug.Log(isAggressive ? "Switching to aggressive mode" : "Switching to passive mode");

            yield return new WaitForSeconds(Random.Range(2f, 5f));
        }
    }

    private void Update()
    {
        if (isAggressive)
        {
            RotateWeapon();
            laser.enabled = true;
            laser.SetPosition(0, SniperWeaponAnchorPoint.transform.position);
            laser.SetPosition(1, playerObject.transform.position);
            if (!stopLaser && !canDealDamage)
            {
                StopCoroutine(nameof(DelayedDamage));
                StartCoroutine(DelayedDamage());
            }
        }
        else
        {
            if (laser.enabled)
            {
                StartCoroutine(StopLaserAfterDelay(1f));
            }
            canDealDamage = false;
        }
    }

    private IEnumerator StopLaserAfterDelay(float delay)
    {
        stopLaser = true;

        yield return new WaitForSeconds(delay);

        laser.enabled = false;
        stopLaser = false;
    }

    private void RotateWeapon()
    {
        Vector2 direction = playerObject.transform.position - SniperWeaponAnchorPoint.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        SniperWeaponAnchorPoint.transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private IEnumerator DelayedDamage()
    {
        while (true)
        {
            if (canDealDamage)
            {
                Vector2 direction = (playerObject.transform.position - SniperWeaponAnchorPoint.transform.position).normalized;
                RaycastHit2D hit = Physics2D.Raycast(SniperWeaponAnchorPoint.transform.position, direction, Mathf.Infinity, playerLayerMask);

                if (hit.collider != null && hit.collider.gameObject.CompareTag("Player"))
                {
                    playerObject.GetComponent<PlayerHealth>().takeDamage(damageAmount);
                    Debug.Log("Player hit after delay.");
                }
            }

            canDealDamage = false;

            yield return new WaitForSeconds(damageDelay);

            canDealDamage = true;
        }
    }

    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);
        canDealDamage = false;
    }
}