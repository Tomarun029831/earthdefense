using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// phase, result

public class GameManager : MonoBehaviour
{
    public Transform parent_for_enemy;

    // point
    public int clean_energy_points;

    // phase
    public int phase;
    public int max_phase;
    public float phaseDuration;
    public float phaseBreak;
    public float preparation_time;

    // wave
    public int wave;
    public int waveTime;
    public float waveBreak;

    // spawn
    public float spawnBreak;
    private SpawnManager spawnManager;


    // Earth health
    public int earth_health;

    // time
    public float time;

    // enemy
    public string enemyPath;
    private GameObject[] enemyPrehubs;

    public GameObject successUI;
    public GameObject failUI;

    public GameObject skipButton;
    void Awake()
    {
        time = 0;
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        parent_for_enemy = GameObject.Find("EnemyParent")?.transform;

        if (parent_for_enemy == null)
        {
            parent_for_enemy = new GameObject("EnemyParent").transform;
        }

        enemyPrehubs = LoadEnemies(enemyPath);
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
        }
        if (phase == 2 && time > 135)
        {
            successUI.SetActive(true);
            Time.timeScale = 0;
        }
    }

    IEnumerator StartGame()
    {
        yield return new WaitUntil(() => phase != 0);
        while (phase < max_phase)
        {
            yield return StartCoroutine(StartPhase());
            Debug.Log("bb");
            yield return new WaitForSeconds(phaseBreak);
        }
    }

    IEnumerator StartPhase()
    {
        float phaseTime = Time.time;
        time = 0;
        while (Time.time - phaseTime < phaseDuration)
        {
            yield return StartWave();
            yield return new WaitForSeconds(waveBreak);
        }
        Debug.Log("aa");
        phase++;
        wave = 0;
        yield break;
    }

    IEnumerator StartWave()
    {
        for (int i = 0; i < waveTime; i++)
        {
            // Debug.Log($"phase:{phase}, wave:{wave}, i:{i}");
            Instantiate(enemyPrehubs[UnityEngine.Random.Range(0, enemyPrehubs.Length)], parent_for_enemy);

            if (i < waveTime - 1)
            {
                yield return new WaitForSeconds(spawnBreak);
            }
        }
        wave++;
        yield break;
    }
    void ShowResult()
    {
        failUI.SetActive(true);
        Time.timeScale = 0;
    }

    [ContextMenu("Skip Preparation")]
    public void SkipPreparation()
    {
        if (phase == 0)
        {
            phase++;
            skipButton.SetActive(false);
            StartCoroutine(StartGame());
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

    public void Restart()
    {
        SceneManager.LoadScene("InGameScene");
        earth_health = 36;
        Time.timeScale = 1;
    }
}
