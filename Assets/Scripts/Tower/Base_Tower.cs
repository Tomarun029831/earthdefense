using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Base_Tower : MonoBehaviour
{
    abstract public void Action(); // attack, buff, debuff, etc.
    abstract public void TakeDamage(float damage); // take damage
    abstract public void Upgrade(); // upgrade tower
    abstract public void Sell(); // sell tower
}
