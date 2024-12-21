using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SpawnManager : MonoBehaviour
{

    void Awake()
    {
    }

    void Start()
    {

    }



    public void Spawn(GameObject _enemy, Transform _parent)
    {
        Instantiate(_enemy, transform.position + 9000 * Vector3.up, Quaternion.identity, _parent);
    }
}
