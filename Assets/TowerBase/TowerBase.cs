using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBase : MonoBehaviour
{
    [NonSerialized]
    public Tower tower = null;
    public GameObject targetedObject;
    public bool Targeted
    {
        get { return targeted; }
        set
        {
            if (targeted != value)
            {
                targetedObject.SetActive(value);
                targeted = value;
            }
        }
    }
    public bool targeted = false;

    void Update()
    {
        Targeted = false;
    }

    public void Build(GameObject newTower)
    {
        tower = Instantiate(newTower, transform.position, Quaternion.identity, transform).GetComponent<Tower>();
    }
}
