using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Truck : Base_Enemy
{
    // test
    // public Base_Tower target;

    // health
    public float max_health;
    public float current_health;

    // damage
    public float max_damage;

    // action
    public float action_interval;
    public float action_range;

    // time
    private float time;

    // game manager
    private GameManager gameManager;

    void Awake()
    {
        gameObject.AddComponent<CinemachineDollyCart>().m_Path = GameObject.Find("Path_" + Random.Range(0, 2)).GetComponent<CinemachinePath>();
        gameObject.GetComponent<CinemachineDollyCart>().m_Speed = Random.Range(1, 3);

        action_interval = 5;
        action_range = 20;
        max_health = 5;
        current_health = max_health;
        max_damage = 1;
        time = 0;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Start()
    {
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= action_interval)
        {
            Action(Find());
            time = 0;
        }
        if (current_health <= 0)
        {
            Die();
        }
    }


    public override void Action(Base_Tower _target) // attack enemy
    {
        Debug.Log(_target.name);
        // Co2 をだす処理
        _target.TakeDamage(max_damage);
    }

    public override void TakeDamage(float damage)
    {
        current_health -= damage;
    }

    public override void Heal(float _value)
    {
        current_health += _value;
        if (current_health > max_health)
        {
            current_health = max_health;
        }
    }


    public override void Die()
    {
        Destroy(gameObject);
    }
    public override Base_Tower Find()
    {
        Base_Tower[] towers = FindObjectsByType<Base_Tower>(FindObjectsSortMode.None);
        foreach (Base_Tower tower in towers)
        {
            if ((tower.transform.position - transform.position).sqrMagnitude <= action_range * action_range)
            {
                return tower;
            }
        }
        return null;
    }


}