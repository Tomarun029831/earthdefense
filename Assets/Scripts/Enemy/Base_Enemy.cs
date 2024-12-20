using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Base_Enemy : MonoBehaviour
{
    abstract public void Action(); // attack, buff, debuff, etc.

    abstract public void Die(); // die
    abstract public void TakeDamage(float damage); // take damage
}
