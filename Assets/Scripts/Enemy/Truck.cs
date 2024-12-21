using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
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
        action_interval = 5;
        action_range = 10;
        max_health = 5;
        current_health = max_health;
        max_damage = 1;
        time = 0;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Start()
    {
        gameObject.GetComponent<CinemachineDollyCart>().m_Speed = 3;
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= action_interval)
        {
            Base_Tower target = Find();
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


    public override void Action(Base_Tower _target) // attack enemy
    {
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
        Base_Tower[] towers = FindObjectsByType<Base_Tower>(FindObjectsSortMode.None);  // Base_Tower 型のオブジェクトを検索
        foreach (Base_Tower tower in towers)
        {
            // 高さ（y座標）を無視して、x と z 座標だけを使用
            Vector3 towerPosition = tower.transform.position;
            Vector3 truckPosition = transform.position;
            towerPosition.y = 0;  // 高さを無視
            truckPosition.y = 0;  // 高さを無視

            if (Mathf.Abs(Vector3.Distance(tower.transform.position, gameObject.transform.position)) <= action_range)
            {
                return tower;  // 範囲内にあるタワーを返す
            }
        }
        return null;  // 範囲内にタワーが見つからなかった場合
    }


    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Earth")
        {
            Die();
        }
    }

}