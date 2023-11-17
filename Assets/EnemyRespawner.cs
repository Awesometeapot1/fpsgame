using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // The prefab of the enemy you want to respawn
    public Transform respawnPoint;  // The point where the enemy should respawn
    public float respawnTime = 500000f;  // Time delay before respawning the enemy

    private void Start()
    {
        // Call the method to start the respawn process
    }

    public void RespawnEnemy()
    {
        // Instantiate the enemy prefab at the respawn point
        GameObject newEnemy = Instantiate(enemyPrefab, respawnPoint.position, respawnPoint.rotation);

        // You can optionally set up other properties of the enemy here, such as health, etc.

        // Invoke the RespawnEnemy method again after the specified respawnTime
    }
}
