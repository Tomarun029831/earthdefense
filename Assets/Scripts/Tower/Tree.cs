using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : Base_Tower
{
    // test
    // public Base_Enemy target;

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


    public override void Action(Base_Enemy _target) // attack enemy
    {
        Debug.Log("Tree is attacking to " + _target.name);

        // Co2 を吸収する処理
        _target.TakeDamage(max_damage);
        current_health += heal_value;
    }

    public override void TakeDamage(float damage)
    {
        // Treeタワーがダメージを受けた時の処理を実装
        Debug.Log($"Tree Tower took {damage} damage");
    }

    public override void Upgrade()
    {
        // Treeタワーのアップグレード処理を実装
        Debug.Log("Tree Tower has been upgraded");
    }

    public override void Sell()
    {
        // Treeタワーを売る処理を実装
        Debug.Log("Tree Tower has been sold");
    }

    public override void Die()
    {
        // Treeタワーが倒れた時の処理を実装
        Debug.Log("Tree Tower has been destroyed");
    }
}
