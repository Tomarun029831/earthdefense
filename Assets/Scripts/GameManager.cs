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
        if (current_phase == 0) // zero phase is preparation phase
        {
            if (time >= preparation_time)
            {
                NextPhase();
                time = 0;
            }
        }
        else
        {
            if (time >= phase_interval) // phase interval
            {
                NextPhase();
                time = 0;
            }
        }
    }

    [ContextMenu("Skip Preparation")]
    void SkipPreparation()
    {
        if (current_phase == 0)
        {
            NextPhase();
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
