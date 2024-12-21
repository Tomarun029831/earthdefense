using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Tower : Base_Tower
{
    // cost
    public int build_cost = 20;
    public int sell_cost = 15;
    public int upgrade_cost = 20;

    // heal
    public float heal_value;

    // health
    public float max_health;
    [NonSerialized]
    public float current_health;

    // damage
    public float max_damage;

    // action
    public float action_interval;
    public float action_range;
    private float absorbableSqrDistance;

    // level
    public int level;
    // public string load_path = "Models/Tower/Tree";
    // private GameObject[] level_prehub;

    public GameObject newTower;

    public Sprite icon;
    public string towerName;

    // time
    private float time;

    // game manager
    [NonSerialized]
    public GameManager gameManager;

    void Awake()
    {
        time = 0;
        level = 1;
        max_health = 25;
        current_health = max_health;
        max_damage = 5;
        action_interval = 1;
        action_range = 10;
        heal_value = 0.1f;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Start()
    {
        absorbableSqrDistance = Mathf.Pow(action_range, 2);
        if (gameManager.clear_energy_points >= build_cost)
        {
            gameManager.clear_energy_points -= build_cost;
        }
        else
        {
            Die();
        }
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= action_interval)
        {
            Base_Enemy target = Find();
            if (target != null)
            {
                Action(target);
            }
            time = 0;
        }
        if (current_health <= 0)
        {
            Die();
        }
    }


    public override void Action(Base_Enemy _target) // attack enemy
    {
        _target.TakeDamage(max_damage, gameObject);
        Heal(heal_value);
    }

    public override void Heal(float _value)
    {
        current_health += _value;
        if (current_health > max_health)
        {
            current_health = max_health;
        }
    }

    public override void TakeDamage(float damage, GameObject _from)
    {
        current_health -= damage;
    }

    // [ContextMenu("Upgrade")]
    // public override void Upgrade()
    // {
    //     gameManager.clear_energy_points -= upgrade_cost;
    //     // level++;
    //     // max_health += 10;
    //     // max_damage += 10;
    //     // action_interval -= 0.1f;


    //     if (level_prehub.Length >= level)
    //     {

    //         if (transform.childCount > 0)
    //         {
    //             Transform currentTower = transform.GetChild(0);
    //             currentTower.gameObject.SetActive(false);
    //         }


    //         newTower = Instantiate(level_prehub[level - 1], transform.position, Quaternion.identity);
    //         newTower.transform.SetParent(transform.parent);


    //         newTower.hideFlags = HideFlags.HideInHierarchy;
    //     }

    //     absorbableSqrDistance = Mathf.Pow(action_range, 2);
    // }

    [ContextMenu("Sell")]
    public override void Sell()
    {
        gameManager.clear_energy_points += sell_cost;
        if (newTower != null)
        {
            Destroy(newTower);
        }
        Destroy(gameObject);
    }

    [ContextMenu("Die")]
    public override void Die()
    {
        if (newTower != null)
        {
            Destroy(newTower);
        }
        Destroy(gameObject);
    }
    public override Base_Enemy Find()
    {
        Base_Enemy target = null;
        float targetPathPos = 0;
        for (int i = 0; i < gameManager.parent_for_enemy.childCount; i++)
        {
            Transform enemy = gameManager.parent_for_enemy.GetChild(i);
            float enemyPathPos = enemy.GetComponent<CinemachineDollyCart>().m_Position;

            if (Mathf.Abs(Vector3.Distance(transform.position, enemy.position)) < action_range && targetPathPos < enemyPathPos)
            {
                target = enemy.GetComponent<Base_Enemy>();
                targetPathPos = enemyPathPos;
            }
        }
        return target;
    }

    // public void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawWireSphere(transform.position, action_range);
    // }
}
