using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Base_Tower : MonoBehaviour
{
    // public float health;
    // public float damage;
    // public float action_interval;
    // public float action_range;

    abstract public void Action(Base_Enemy _target); // attack, buff, debuff, etc.
    abstract public void TakeDamage(float damage); // take damage

    abstract public void Upgrade(); // upgrade tower
    abstract public void Sell(); // sell tower
}
