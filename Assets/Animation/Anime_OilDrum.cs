using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anime_OilDrum : MonoBehaviour
{
    public float timer = 0;
    public float Rotate_Interval = 1;
    public Vector3 Rotate_angle = new Vector3(0, 1, 0);

    void Update()
    {
        timer += Time.deltaTime;
        Debug.Log("drum");
        if (timer >= Rotate_Interval)
        {
            timer = 0;
            transform.Rotate(Rotate_angle);
        }
    }
}
