using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    Vector3 lastSpawn;
    [SerializeField] int startingPlanets = 4;
    [SerializeField] PlayerInput player;
    GameObject lastTouchedPlanet;
    [SerializeField] float spawnYDistance = 4f;
    [SerializeField] float spawnYDistanceVariation = 0f;
    [SerializeField] float minimumSpawnYDistance = 3.5f;
    [SerializeField] float spawnXRange = 3f;
    [SerializeField] GameObject planetToSpawn;

    void Start()
    {
        if (player.targetPlanet != null)
        {
            lastSpawn = player.targetPlanet.transform.position;
            lastTouchedPlanet = player.targetPlanet;
            SpawnStartingPlanets();
        }
        else
        {
            Debug.Log("No starting planet detected!");
        }
    }

    void Update()
    {
        CheckPlayerStatus();
    }

    void CheckPlayerStatus()
    {
        if (lastTouchedPlanet != player.targetPlanet && player.targetPlanet != null)
        {
            SpawnPlanet();
            Destroy(lastTouchedPlanet, 10f);
            lastTouchedPlanet = player.targetPlanet;
        }
    }

    void SpawnStartingPlanets()
    {
        for (int n = 0; n < startingPlanets; n++)
        {
            SpawnPlanet();
        }
    }

    void SpawnPlanet()
    {
        float spawnX = lastSpawn.x + Random.Range(-spawnXRange, spawnXRange); // Might want to use Mathf.clamp later for security.
        float spawnY = lastSpawn.y + Mathf.Clamp(spawnYDistance + Random.Range(-spawnYDistanceVariation, spawnYDistanceVariation), minimumSpawnYDistance, Mathf.Infinity);
        Vector3 spawnLocation = new Vector3 (spawnX, spawnY, 0f);

        Instantiate(planetToSpawn, spawnLocation, Quaternion.identity);
        lastSpawn = spawnLocation;
    }
}
