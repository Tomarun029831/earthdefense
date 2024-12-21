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
        Instantiate(_enemy, transform.position, Quaternion.identity, _parent).
        AddComponent<CinemachineDollyCart>().m_Path =
        GameObject.Find("Path_" + Random.Range(0, 2)).GetComponent<CinemachinePath>();
    }
}
