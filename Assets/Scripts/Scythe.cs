using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ScytheController : MonoBehaviour
{
    public GameObject scythePrefab;
    public float speed;
    public float spinSpeed;


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit enemy: " + collision.gameObject.name); // Output the name of the enemy object
        }
    }
    void Update()
    {
        // Check for mouse input
        if (Input.GetMouseButtonDown(0))
        {
            // Get mouse position
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0f;

            // Instantiate scythePrefab
            GameObject scythe = Instantiate(scythePrefab, transform.position, Quaternion.identity);

            // Calculate direction towards the cursor
            Vector3 direction = (targetPosition - scythe.transform.position).normalized;

            // Rotate the scythe to face the cursor direction
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            scythe.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // Apply continuous spinning to the scythe
            Rigidbody2D rb = scythe.GetComponent<Rigidbody2D>();
            rb.angularVelocity = spinSpeed; // Set the angular velocity for spinning

            // Move scythe towards the cursor
            rb.velocity = direction * speed;
            Destroy(scythe, 2f);
        }

    }
}