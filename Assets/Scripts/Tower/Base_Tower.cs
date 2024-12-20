using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Base_Tower : MonoBehaviour
{
    // // health
    // public float max_health;
    // public float current_health;

    // // damage
    // public float max_damage;

    // // action
    // public float action_interval;
    // public float action_range;

    // // heal
    // public float heal_value;

    abstract public void Find(); // find enemy
    abstract public void Action(Base_Enemy _target); // attack, buff, debuff, etc.
    abstract public void TakeDamage(float damage); // take damage
    abstract public void Heal(float _value); // heal
    abstract public void Die(); // tower die

    abstract public void Upgrade(); // upgrade tower
    abstract public void Sell(); // sell tower
}
