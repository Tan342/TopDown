using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWeapon : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject[] weaponPrefab;
    [SerializeField] GameObject spawnPos;
    [SerializeField] float timeSpawn = 5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        int pos = Random.Range(0, spawnPoints.Length);
        int weapon = Random.Range(0, weaponPrefab.Length);
        GameObject e = Instantiate(weaponPrefab[weapon], spawnPoints[pos].position, Quaternion.identity);
        e.transform.parent = spawnPos.transform;
        yield return new WaitForSeconds(timeSpawn);
        StartCoroutine("Spawn");
    }
}
