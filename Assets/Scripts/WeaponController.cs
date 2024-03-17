using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject bulletprefab;
    public GameObject pistol;

    public Transform pistolFirePoint;

    public float pistolBulletForce = 20f;

    public float pistolFireRate = 0.5f;

    private float pistolFireTimer = 0f;
    private Camera mainCamera;

    void Start()
    {
        mainCamera= Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 pistolPosition = transform.position; // Assuming the script is attached to the pistol GameObject
        Vector2 direction = (mousePosition - pistolPosition).normalized;

        // Calculate rotation angle from direction vector
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Set pistol rotation
        transform.rotation = Quaternion.Euler(0f, 0f,angle -180f);
        pistolFireTimer -= Time.deltaTime;
        if(pistolFireTimer <= 0f )
        {
            firePistol();
            pistolFireTimer = pistolFireRate;
        }
    }
    void firePistol()
    {
        // Calculate direction from fire point to mouse position
        Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 firePointPosition = pistolFirePoint.position;
        Vector2 direction = (mousePosition - firePointPosition).normalized;

        // Calculate rotation angle from direction vector
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Set bullet rotation
        Quaternion bulletRotation = Quaternion.Euler(0f, 0f, angle - 90f); // Adjust for sprite orientation
        GameObject bullet = Instantiate(bulletprefab, firePointPosition, bulletRotation);

        // Get the Rigidbody2D component of the bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Apply velocity to the bullet to make it move in the calculated direction
        rb.velocity = direction * pistolBulletForce;
    }


}