using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet : MonoBehaviour
{
    public float life = 15f;          // Bullet lifetime before self-destruction
    public float arcHeight = 5f;     // Height of the parabolic trajectory

    void Awake()
    {
        Destroy(gameObject, life);   // Destroy bullet after 'life' seconds
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            return;                  // Ignore collisions with the ground
        }
        else if (collision.gameObject.CompareTag("Terrain")){
            return;
        }
        else
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                Vector3 playerPosition = player.transform.position;
                StartCoroutine(MoveInParabola(playerPosition, 1.5f)); // Adjust duration as needed
            }
        }
        ScoreCounter scoreCounter = FindFirstObjectByType<ScoreCounter>();
        scoreCounter.AddScore(1);
        Destroy(collision.gameObject);
    }

    IEnumerator MoveInParabola(Vector3 targetPosition, float duration)
    {
        Vector3 startPosition = transform.position;
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            float t = timeElapsed / duration;

            // Calculate height offset for the parabola
            float heightOffset = arcHeight * Mathf.Sin(Mathf.PI * t);
            Vector3 currentPosition = Vector3.Lerp(startPosition, targetPosition, t);
            currentPosition.y += heightOffset;

            transform.position = currentPosition;

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;  // Snap to final position
    }
}