using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : Base_Tower
{
    // Start is called before the first frame update
    void Start()
    {
        // Treeの初期化コード
        Debug.Log("Tree Tower Initialized");
    }

    // Update is called once per frame
    void Update()
    {
        // Treeの更新処理
        // 例えば、毎フレーム行うアクションがあればここに書く
        Debug.Log("Tree Tower Updated");
    }

    // Base_Tower から継承した抽象メソッドを実装

    public override void Action() // attack enemy
    {
        Debug.Log("Tree Tower is performing an action");

        // Co2 を生成してそれを吸収する処理
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
