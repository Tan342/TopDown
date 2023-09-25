using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject[] enemyPrefab;
    [SerializeField] float timeSpawn = 2f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        int pos = Random.Range(0, spawnPoints.Length);
        int enemy = Random.Range(0, enemyPrefab.Length);
        Instantiate(enemyPrefab[enemy], spawnPoints[pos].position, Quaternion.identity);
        yield return new WaitForSeconds(timeSpawn);
        StartCoroutine("Spawn");
    }
}