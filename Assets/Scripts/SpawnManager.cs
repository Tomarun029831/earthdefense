using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SpawnManager : MonoBehaviour
{
    public float spawn_interval;

    // time
    private float time;

    // enemy
    public string enemyPath;
    private GameObject[] enemyPrefabs;
    private Transform enemyParent;


    void Awake()
    {
        time = 0;
        enemyPrefabs = LoadEnemies(enemyPath);
        enemyParent = GameObject.Find("EnemyParent").transform;
    }

    void Start()
    {

    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= spawn_interval)
        {
            Spawn();
            time = 0;
        }
    }

    GameObject[] LoadEnemies(string path)
    {
        string[] strings = { "Assets/", "Resources/" };
        foreach (string s_trim in strings)
        {
            path = path.TrimStart(s_trim.ToCharArray());
        }
        return Resources.LoadAll<GameObject>(path);
    }

    void Spawn()
    {
        GameObject enemy = Instantiate
        (
            enemyPrefabs[Random.Range(0, enemyPrefabs.Length)],
            transform.position,
            Quaternion.identity,
            enemyParent
         );
    }
}
