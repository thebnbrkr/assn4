using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectible : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("How fast the coin rotates")]
    public float rotationSpeed = 100f;
    
    [Tooltip("Sound to play when coin is collected")]
    public AudioClip collectionSound;

    [Header("Visual Effects")]
    [Tooltip("Optional particle system to play when collected")]
    public GameObject collectionEffect;

    private bool isCollected = false;

    // Rotate the coin continuously
    void Update()
    {
        // Rotate the coin around the Y axis
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        
        // Check for nearby player (alternative to OnTriggerEnter)
        CheckForPlayer();
    }
    
    // Check if player is close enough to collect
    void CheckForPlayer()
    {
        // Skip if already collected
        if (isCollected) return;
        
        // Find the player (by tag)
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            // Calculate distance to player
            float distance = Vector3.Distance(transform.position, player.transform.position);
            
            // If player is close enough (adjust this value as needed)
            if (distance < 1.0f)
            {
                Collect();
            }
        }
    }

    // Handle collection logic
    void Collect()
    {
        Debug.Log("Collecting coin!");
        isCollected = true;
        
        // Add to score through the ScoreManager
        ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        if (scoreManager != null)
        {
            Debug.Log("Found ScoreManager, adding point");
            scoreManager.AddPoint();
        }
        else
        {
            Debug.LogError("No ScoreManager found in the scene!");
        }

        // Play sound if available
        if (collectionSound != null)
        {
            AudioSource.PlayClipAtPoint(collectionSound, transform.position);
        }

        // Spawn collection effect if available
        if (collectionEffect != null)
        {
            Instantiate(collectionEffect, transform.position, Quaternion.identity);
        }

        // Destroy the coin game object
        Destroy(gameObject);
    }
}