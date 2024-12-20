using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CO2 : MonoBehaviour
{
    public float duration;
    [NonSerialized]
    public Vector3 target;
    private Vector3 initialPos;
    private float timer = 0;

    void Start(){
        initialPos = transform.position;
    }

    void Update(){
        timer += Time.deltaTime;
        if(timer > duration) Destroy(gameObject);
        transform.position = Vector3.Lerp(initialPos, target, timer / duration);
    }
}
