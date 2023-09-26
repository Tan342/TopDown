using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject[] enemyPrefab;
    [SerializeField] GameObject posSpawn;
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
        GameObject e = Instantiate(enemyPrefab[enemy], spawnPoints[pos].position, Quaternion.identity);
        e.transform.parent = posSpawn.transform;
        yield return new WaitForSeconds(timeSpawn);
        StartCoroutine("Spawn");
    }
}