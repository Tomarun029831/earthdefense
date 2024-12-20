using System.Collections;
using System.Collections.Generic;
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

    // heal
    public float heal_value;

    // time
    private float time = 0;

    void Start()
    {
        // Treeの初期化コード
        Debug.Log("Tree Tower Initialized");
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= action_interval)
        {
            Action(null);
            time = 0;
        }
    }


    public override void Action(Base_Tower _target) // attack enemy
    {
        Debug.Log("Truck is attacking to " + _target.name);

        // Co2 をだす処理
        _target.TakeDamage(max_damage);
    }

    public override void TakeDamage(float damage)
    {
        // Treeタワーがダメージを受けた時の処理を実装
        Debug.Log($"Truck Tower took {damage} damage");

        current_health -= damage;
    }


    public override void Die()
    {
        Debug.Log("Truck is dead");

    }
}