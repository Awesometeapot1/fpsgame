using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // The prefab of the enemy you want to respawn
    public Transform respawnPoint;  // The point where the enemy should respawn
    public Transform respawnPoint1;  // The point where the enemy should respawn
    public Transform respawnPoint2;  // The point where the enemy should respawn
    public Transform respawnPoint3;  // The point where the enemy should respawn
    public Transform respawnPoint4;  // The point where the enemy should respawn
    Gamecontroller gameController; // This will hold the reference to the GameController script.

    public float respawnTime = 500000f;  // Time delay before respawning the enemy

    private void Start()
    {
        gameController = GameObject.Find("Main Camera").GetComponent<Gamecontroller>();

        // Call the method to start the respawn process
    }

    public void RespawnEnemy()
    {
        // Instantiate the enemy prefab at the respawn point
        if (gameController.currentLevel == 1)
        {
            Instantiate(enemyPrefab, respawnPoint.position, respawnPoint.rotation);

        }

        else if (gameController.currentLevel == 2)
        {
            Instantiate(enemyPrefab, respawnPoint.position, respawnPoint.rotation);
            Instantiate(enemyPrefab, respawnPoint1.position, respawnPoint.rotation);
        }
        else if (gameController.currentLevel == 3)
        {
            Instantiate(enemyPrefab, respawnPoint.position, respawnPoint.rotation);
            Instantiate(enemyPrefab, respawnPoint1.position, respawnPoint.rotation);
            Instantiate(enemyPrefab, respawnPoint2.position, respawnPoint.rotation);
        }
        else if (gameController.currentLevel == 4)
        {
            Instantiate(enemyPrefab, respawnPoint.position, respawnPoint.rotation);
            Instantiate(enemyPrefab, respawnPoint1.position, respawnPoint.rotation);
            Instantiate(enemyPrefab, respawnPoint2.position, respawnPoint.rotation);
            Instantiate(enemyPrefab, respawnPoint3.position, respawnPoint.rotation);
        }
        else if (gameController.currentLevel == 5)
        {
            Instantiate(enemyPrefab, respawnPoint.position, respawnPoint.rotation);
            Instantiate(enemyPrefab, respawnPoint1.position, respawnPoint.rotation);
            Instantiate(enemyPrefab, respawnPoint2.position, respawnPoint.rotation);
            Instantiate(enemyPrefab, respawnPoint3.position, respawnPoint.rotation);
            Instantiate(enemyPrefab, respawnPoint4.position, respawnPoint.rotation);
        }

        // You can optionally set up other properties of the enemy here, such as health, etc.

        // Invoke the RespawnEnemy method again after the specified respawnTime
    }
}
