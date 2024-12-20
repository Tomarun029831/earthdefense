using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Base_Enemy : MonoBehaviour
{
    // public float health;
    // public float damage;
    // public float action_interval;
    // public float action_range;


    abstract public Base_Tower Find(); // find enemy
    abstract public void Action(Base_Tower _tower); // attack, buff, debuff, etc.
    abstract public void TakeDamage(float damage); // take damage
    abstract public void Heal(float _value); // heal

    abstract public void Die(); // die
}
