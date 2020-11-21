using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_EnemySpawnPoint : MonoBehaviour
{
    float timer;
    public float initialTimer = 5f;
    public GameObject[] itemsToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        timer = initialTimer;

    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0) timer -= Time.deltaTime;
        if (timer <= 0)
        {
            int randomIndex = Random.Range(0, itemsToSpawn.Length);
            GameObject shipToSpawn = itemsToSpawn[randomIndex];
            SpawnShip(shipToSpawn);
            timer = initialTimer;
        }
    }

    void SpawnShip (GameObject shipToSpawn)
    {
        Instantiate(shipToSpawn, transform.position, Quaternion.identity);
    }
}
