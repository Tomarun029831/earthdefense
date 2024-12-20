using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : Base_Tower
{
    public float max_health;
    public float max_damage;

    public float health;

    public float damage;
    public float action_interval;
    public float action_range;

    void Start()
    {
        // Treeの初期化コード
        Debug.Log("Tree Tower Initialized");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Action(Base_Enemy _target) // attack enemy
    {
        Debug.Log("Tree is attacking to " + _target.name);

        // Co2 を吸収する処理
        _target.TakeDamage(damage);
        health += 1;
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
}
