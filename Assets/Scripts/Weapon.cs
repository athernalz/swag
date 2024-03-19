using UnityEngine;
using System.Collections;

public class ScytheAttack : MonoBehaviour
{
    public int damage = 10;
    public float swipeSpeed = 5.0f; // Speed of the swipe
    public float swipeDelay = 2.0f; // Delay between swipes
    public Transform anchorPoint; // Anchor point for rotation

    private Vector3 startPos;
    private Vector3 endPos;
    private bool isSwiping = false;

    void Start()
    {
        // Set the start and end positions for swiping
        startPos = transform.position;
        endPos = new Vector3(-10f, transform.position.y, transform.position.z); // Adjust -10f based on your scene
        StartCoroutine(StartSwiping());
    }

    IEnumerator StartSwiping()
    {
        while (true)
        {
            // Swipe from startPos to endPos
            yield return StartCoroutine(Swipe(startPos, endPos));

            // Delay before swiping again
            yield return new WaitForSeconds(swipeDelay);

            // Swipe back from endPos to startPos
            yield return StartCoroutine(Swipe(endPos, startPos));
        }
    }

    IEnumerator Swipe(Vector3 start, Vector3 end)
    {
        float distance = Vector3.Distance(start, end);
        float duration = distance / swipeSpeed;
        float elapsedTime = 0f;

        isSwiping = true;

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            transform.position = Vector3.Lerp(start, end, t);

            // Interpolate the rotation between start and end positions
            Vector3 direction = (end - start).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the scythe reaches the end position exactly
        transform.position = end;
        transform.rotation = Quaternion.identity; // Reset rotation

        isSwiping = false;
    }

    void RotateTowardsMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Vector3 direction = mousePos - anchorPoint.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        anchorPoint.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (!isSwiping) // Ensure damage is dealt only when swiping
            {
                // Deal damage to the enemy
                other.GetComponent<Enemy>().TakeDamage(damage);
                Debug.Log("Hit enemy");
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Add Gizmos drawing here if needed
    }
}
