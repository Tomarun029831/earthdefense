using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Base_Enemy
{
    // points
    public int points;

    // bullet
    public GameObject bullet;

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
        time = 0;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Start()
    {
        gameObject.GetComponent<CinemachineDollyCart>().m_Speed = 9;
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
        Instantiate(bullet, transform.position, Quaternion.identity).GetComponent<CO2>().target = _target.transform.position;

        _target.TakeDamage(max_damage, gameObject);
    }

    public override void TakeDamage(float damage, GameObject _from)
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
        gameManager.clean_energy_points += points;
        Destroy(gameObject);
    }

    public override Base_Tower Find()
    {
        Base_Tower[] towers = FindObjectsByType<Base_Tower>(FindObjectsSortMode.None);
        foreach (Base_Tower tower in towers)
        {
            Vector3 towerPosition = tower.transform.position;
            Vector3 truckPosition = transform.position;
            towerPosition.y = 0;
            truckPosition.y = 0;

            if (Mathf.Abs(Vector3.Distance(tower.transform.position, gameObject.transform.position)) <= action_range)
            {
                return tower;
            }
        }
        return null;
    }


    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Earth"))
        {
            gameManager.earth_health -= 1;
            Die();
        }
    }

}
