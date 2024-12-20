using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Base_Enemy : MonoBehaviour
{
    // public float health;
    // public float damage;
    // public float action_interval;
    // public float action_range;

    public abstract void Action(GameObject gameObject); // attack, buff, debuff, etc.
    public abstract void TakeDamage(float damage); // take damage

    public abstract void Die(); // die
}
