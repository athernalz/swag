using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed;
    public Image xpBar;
    public float currentXP;
    public float maxXP;
    public TMP_Text xpText;
    public TMP_Text levelText;
    public int currentLevel;
    public Canvas upgradeScreen;
    public UpgradesManager upgradesManager;
    public Image kat;
    public int maxHP = 100;
    public int currentHP;
    public Image hpBar;
    public TMP_Text hpText;
    private bool canTakeDamage = true;
    private float damageCooldownTimer = 0f;
    private float damageCooldownDuration = 0.3f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentXP = 0;
        maxXP = 100;
        upgradeScreen.enabled = false;
        upgradeScreen.gameObject.SetActive(false);
        currentHP = maxHP;
    }

    private void Update()
    {
        PlayerMovement();
        XP();
        PlayerHPBar();
        fPlayerDeath();
    }

    void PlayerMovement()
    {
        // Read input for horizontal and vertical movement without smoothing
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Calculate the movement direction
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;

        // Apply movement
        rb.velocity = movement * moveSpeed;
    }

    void addXP(float amount)
    {
        currentXP += amount;
    }

    void levelUp()
    {
        showUpgradeOptions();
        upgradesManager.DisplayRandomPowerups();
        currentLevel++;
        currentXP -= maxXP; // Deduct the excess XP
        maxXP *= 1.5f;
        Debug.Log("Leveled up! Your level is now: " + currentLevel);
    }

    void showUpgradeOptions()
    {
        upgradeScreen.enabled = true;
        upgradeScreen.gameObject.SetActive(true);
    }

    void XP()
    {
        xpBar.fillAmount = currentXP / maxXP;
        xpText.text = $"EXP: {((currentXP / maxXP) * 100f):F1}%";
        levelText.text = currentLevel.ToString();

        // Level up if XP reaches or exceeds maximum
        if (currentXP >= maxXP || xpText.text == "EXP: 100.0%")
        {
            levelUp();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            addXP(50);
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            addXP(8.33f);
        }
    }

    public void takeDamage(int amount)
    {
        if (canTakeDamage)
        {
            currentHP -= amount;
            Debug.Log("Player's health decreased to: " + currentHP);

            if (currentHP <= 0)
            {
                Death();
            }
            else
            {
                canTakeDamage = false;
                damageCooldownTimer = damageCooldownDuration;
                // Flash screen red.
            }
        }
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            takeDamage(10);
        }
    }

    void Death()
    {
        Time.timeScale = 0;
        Debug.Log("Player has died");
        kat.gameObject.SetActive(true);
        currentHP = 0;
    }

    void PlayerHPBar()
    {
        hpBar.fillAmount = (float)currentHP / maxHP;
        hpText.text = currentHP + "/" + maxHP;
    }

    void fPlayerDeath()
    {
        if (currentHP <= 0)
        {
            Destroy(gameObject);
            return;
        }

        if (!canTakeDamage)
        {
            damageCooldownTimer -= Time.deltaTime;
            if (damageCooldownTimer <= 0f)
            {
                canTakeDamage = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            takeDamage(15);
        }
    }

}

