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

    private float time;

    void Awake()
    {
        current_phase = 0;
        time = 0;
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
