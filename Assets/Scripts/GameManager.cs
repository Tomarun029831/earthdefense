using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform enemyParent;

    // phase
    public int current_phase;
    public int max_phase;
    public float phase_interval;
    public float preparation_time;

    // time
    private float time;

    // spawn
    public float spawn_interval;
    private SpawnManager spawnManager;

    void Awake()
    {
        current_phase = 0;
        time = 0;
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        enemyParent = GameObject.Find("EnemyParent").transform;
        if (enemyParent == null)
        {
            enemyParent = new GameObject("EnemyParent").transform;
        }
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= phase_interval && current_phase > 0)
        {
            NextPhase();
            time = 0;
        }
        else if (time >= preparation_time && current_phase == 0)
        {
            NextPhase();
            time = 0;
        }
    }

    void NextPhase()
    {
        if (current_phase < max_phase)
        {
            current_phase++;
        }
    }
}
