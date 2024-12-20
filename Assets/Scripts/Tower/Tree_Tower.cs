using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_Tower : Base_Tower
{
    // test
    public Base_Enemy target;
    public float heal_value;

    // health
    public float max_health;
    public float current_health;

    // damage
    public float max_damage;

    // action
    public float action_interval;
    public float action_range;

    // level
    public int level;

    // time
    private float time = 0;

    // game manager
    private GameManager gameManager;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Start()
    {
        // Treeの初期化コード
        // Debug.Log("Tree Tower Initialized");
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= action_interval)
        {
            Action(null);
            time = 0;
        }
        if (current_health <= 0)
        {
            Die();
        }
    }


    public override void Action(Base_Enemy _target) // attack enemy
    {
        // Debug.Log("Tree is attacking to " + _target.name);

        // Co2 を吸収する処理
        target.TakeDamage(max_damage);
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

    public override void TakeDamage(float damage)
    {
        current_health -= damage;
    }

    [ContextMenu("Upgrade")]
    public override void Upgrade()
    {
        level++;
        max_health += 10;
        max_damage += 10;
        action_interval -= 0.1f;

    }

    [ContextMenu("Sell")]
    public override void Sell()
    {
        Destroy(gameObject);
    }

    public override void Die()
    {
        // Treeタワーが倒れた時の処理を実装
        // Debug.Log("Tree Tower has been destroyed");
        Destroy(gameObject);
    }

    public override Base_Enemy Find()
    {
        Base_Enemy target = null;
        float targetPathPos = 0;
        for (int i = 0; i < gameManager.enemyParent.childCount; i++)
        {
            Transform enemy = gameManager.enemyParent.GetChild(i);
            float enemyPathPos = enemy.GetComponent<CinemachineDollyCart>().m_Position;
            if ((transform.position - enemy.position).sqrMagnitude < absorbableSqrDistance && targetPathPos < enemyPathPos)
            {
                target = enemy.GetComponent<Base_Enemy>();
                targetPathPos = enemyPathPos;
            }
        }
        return target;
    }
}
