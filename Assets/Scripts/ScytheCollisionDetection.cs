using System.Collections;
using UnityEngine;

public class ScytheCollisionDetection : MonoBehaviour
{
    public Color flashColor = new Color(1f, 1f, 1f, 0.5f); // White with reduced opacity
    public float flashDuration = 0.2f; // Duration of each flash
    public int numberOfFlashes = 1; // Number of times to flash

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            SpriteRenderer spriteRenderer = enemy.GetComponent<SpriteRenderer>();
            Debug.Log("Scythe Trigger Hit enemy: " + other.gameObject.name); // Output the name of the enemy object
            enemy.TakeDamage(20);

            if (spriteRenderer != null) // Check if spriteRenderer is not null
            {
                // Start the flashing coroutine without checking isFlashing
                StartCoroutine(FlashEnemy(spriteRenderer));
            }
        }
    }

    IEnumerator FlashEnemy(SpriteRenderer spriteRenderer)
    {
        Color originalColor = spriteRenderer.color; // Store the original color

        for (int i = 0; i < numberOfFlashes; i++)
        {
            if (spriteRenderer != null) // Check if spriteRenderer is not null
            {
                // Overlay the white flash color on top of the original color
                spriteRenderer.color = originalColor + flashColor - new Color(0f, 0f, 0f, originalColor.a); // Ensure the alpha value does not exceed 1
                yield return new WaitForSeconds(flashDuration / 2);

                // Return to the original color
                spriteRenderer.color = originalColor;
                yield return new WaitForSeconds(flashDuration / 2);
            }
            else
            {
                break; // Exit the loop if spriteRenderer is null
            }
        }
    }
}
