using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Base_Enemy : MonoBehaviour
{
    public abstract void Action(); // attack, buff, debuff, etc.
    public abstract void TakeDamage(float damage); // take damage

    public abstract void Die(); // die
}
