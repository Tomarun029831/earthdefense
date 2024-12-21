using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 moveMultiplier;
    void Update(){
        if(Input.GetMouseButton(1))
            transform.position -= new Vector3(Input.mousePositionDelta.x * moveMultiplier.x, 0f, Input.mousePositionDelta.y * moveMultiplier.z);
        transform.position += transform.rotation * Vector3.forward * Input.mouseScrollDelta.y * moveMultiplier.y;
    }
}
