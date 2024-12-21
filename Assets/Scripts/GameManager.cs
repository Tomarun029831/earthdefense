using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform parent_for_enemy;

    // point
    public int clean_energy_points;

    // spawn
    public float spawn_interval;

    // wave
    [NonSerialized]
    public int current_wave;
    public int amount_of_wave; // amount of wave per phase
    public int amount_of_enemy_w; // amount of enemy per wave
    public float wave_interval; // interval between waves

    // phase
    [NonSerialized]
    public int current_phase;
    public int max_phase;
    public float phase_interval;
    public float preparation_time;

    // Earth health
    public int earth_health;

    // time
    private float time;

    // spawn
    private SpawnManager spawnManager;

    // enemy
    public string enemyPath;
    private GameObject[] enemyPrefabs;

    private bool isPhaseRunning = false, isWaveRunning = false;

    void Awake()
    {
        clean_energy_points = 100;
        current_phase = 0;
        current_wave = 0;
        time = 0;
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        parent_for_enemy = GameObject.Find("EnemyParent")?.transform;

        if (parent_for_enemy == null)
        {
            parent_for_enemy = new GameObject("EnemyParent").transform;
        }

        enemyPrefabs = LoadEnemies(enemyPath);
    }

    void Start()
    {
    }

    void Update()
    {
        if (earth_health <= 0)
        {
            ShowResult();
        }
        else
        {
            time += Time.deltaTime;
            if (current_phase == 0) // zero phase is preparation phase
            {
                if (time >= preparation_time)
                {
                    StartCoroutine(StartPhase());
                    time = 0;
                }
            }
            else
            {
                if (time >= phase_interval) // phase interval
                {
                    StartCoroutine(StartPhase());
                    time = 0;
                }
            }
        }
    }

    void ShowResult()
    {

        Time.timeScale = 0;
    }

    IEnumerator StartPhase()
    {
        if (isPhaseRunning)
        {
            yield break;
        }
        float s_time = time;

        isPhaseRunning = true;

        if (current_phase < max_phase)
        {
            Debug.Log("Phase " + current_phase + " started");
            while (true)
            {
                if (time - s_time >= phase_interval)
                {
                    break;
                }
                StartCoroutine(StartWave());
                yield return new WaitForSeconds(wave_interval);
            }
        }

        isPhaseRunning = false;
    }

    IEnumerator StartWave()
    {
        if (isWaveRunning)
        {
            yield break;
        }

        isWaveRunning = true;

        if (current_wave < amount_of_wave)
        {
            Debug.Log("Wave " + current_wave + " started");
            for (int i = 0; i < amount_of_enemy_w * (current_wave + 1); i++)
            {
                spawnManager.Spawn(enemyPrefabs[UnityEngine.Random.Range(0, enemyPrefabs.Length)], parent_for_enemy);
                yield return new WaitForSeconds(spawn_interval);
            }
            current_wave++;
        }
        else
        {
            current_wave = 0;
        }

        isWaveRunning = false;
    }

    [ContextMenu("check wave")]
    void CheckWave()
    {
        Debug.Log("current wave: " + current_wave);
    }

    [ContextMenu("Skip Preparation")]
    void SkipPreparation()
    {
        if (current_phase == 0)
        {
            current_phase++;
            StartCoroutine(StartPhase());
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
}
