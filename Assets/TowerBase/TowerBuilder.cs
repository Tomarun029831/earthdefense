using System;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    // [NonSerialized]
    public GameObject tower; //設置するタワー
    void LateUpdate()
    {
        RaycastHit hit;
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit);
        if (hit.collider != null)
        {
            TowerBase towerBase = hit.collider.GetComponent<TowerBase>();
            if (towerBase == null) return;
            if (Input.GetMouseButtonDown(0))
            {
                towerBase.Build(tower);
                return;
            }
            if (towerBase.tower == null) towerBase.Targeted = true;
        }
    }
}
