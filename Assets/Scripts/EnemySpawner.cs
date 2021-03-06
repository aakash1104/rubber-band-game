﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    MaskedOrc,
    Ogre
}

public class EnemySpawner : MonoBehaviour
{
    public GameObject maskedOrc, ogre;
    private float timer;
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        // Get reference to gamemanager.
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        // Set timer to init.
        timer = gm.EnemyParams.SpawnRate;
        // Spawn first enemy before first frame update.
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        // Timer that determines spawn rate.
        timer -= Time.deltaTime;
        if (timer <= 0) {
            timer = gm.EnemyParams.SpawnRate;
            SpawnEnemy();
        }
    }

    // Spawns enemy prefab in current position with no rotation.
    void SpawnEnemy() {
        Vector3 currentPos = new Vector3(transform.position.x, transform.position.y, 0);
        int randomEnemyType = Random.Range(0, 100);
        if (randomEnemyType <= gm.EnemyParams.OrcSpawnChance) {
            Instantiate(maskedOrc, currentPos, Quaternion.identity);
        } else {
            Instantiate(ogre, currentPos, Quaternion.identity);
        }
    }
}
