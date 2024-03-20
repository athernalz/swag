using UnityEngine;

public class ScytheCollisionDetection : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Scythe Trigger Hit enemy: " + other.gameObject.name); // Output the name of the enemy object
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(20);
        }
    }
}
