using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : Base_Tower
{
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



    public override void Action(GameObject _target) // attack enemy
    {
        Debug.Log("Tree Tower is performing an action");

        // Co2 を吸収する処理
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
