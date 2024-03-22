using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject AcidicSlime;
    public GameObject Sniper;
    public GameObject EnemySpawnRestriction;
    public float EnemySpawnRate = 2; // Time in seconds between spawns
    public GameObject SpawnPos1;
    public int MaxEnemiesToSpawn = 200; // Maximum number of enemies to spawn

    private bool isSpawning = false;
    private int enemiesSpawned = 0; // Counter for spawned enemies

    private void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !isSpawning)
        {
            StartCoroutine(SpawnAcidicSlimes());
        }

        Vector3 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        mouseWorldPosition.z = 0;

        if (Input.GetKeyDown(KeyCode.Alpha1)) // Alpha1 = "1"
        {
            GameObject enemyInstance = Instantiate(AcidicSlime, mouseWorldPosition, Quaternion.identity);
            // Additional setup for instantiated enemy if needed
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) // Alpha2 = "2"
        {
            GameObject enemyInstance = Instantiate(Sniper, mouseWorldPosition, Quaternion.identity);
            // Additional setup for instantiated enemy if needed
        }
    }

    IEnumerator SpawnAcidicSlimes()
    {
        isSpawning = true;
        enemiesSpawned = 0; // Reset the counter every time spawning starts

        while (isSpawning && enemiesSpawned < MaxEnemiesToSpawn)
        {
            float xAxis = SpawnPos1.transform.position.x;
            float yAxis = SpawnPos1.transform.position.y;

            Instantiate(AcidicSlime, new Vector2(xAxis, yAxis), Quaternion.identity);
            enemiesSpawned++;
            Debug.Log($"Spawned enemy at {Time.time}. Next enemy will spawn in {EnemySpawnRate} seconds.");

            yield return new WaitForSeconds(EnemySpawnRate); // Wait for specified spawn rate
        }

        isSpawning = false; // Stop spawning when max count is reached
    }
}
