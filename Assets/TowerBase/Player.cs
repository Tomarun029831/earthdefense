using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public TowerInfo towerInfo;
    public TowerBuild towerBuild;
    private bool pushingButton;
    // public int money;

    void LateUpdate()
    {
        RaycastHit hit;
        TowerBase towerBase = null;
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit);
        if (Input.GetMouseButtonDown(0)) pushingButton = true;
        if (Input.mousePositionDelta != Vector3.zero) pushingButton = false;
        if (hit.collider != null)
        {
            towerBase = hit.collider.GetComponent<TowerBase>();
            if (towerBase != null)
            {
                if (towerBase.tower == null) towerBase.Targeted = true;
                if (Clicked())
                {
                    if (towerBase.tower == null)
                    {
                        towerBuild.SetBase(towerBase);
                    }
                    else
                    {
                        towerInfo.SetTower(towerBase);
                    }
                }
            };
        }
        if ((hit.collider == null || towerBase == null) && Clicked())
        {
            towerBuild.gameObject.SetActive(false);
            towerInfo.gameObject.SetActive(false);
        }
    }

    private bool Clicked()
    {
        return Input.GetMouseButtonUp(0) && pushingButton && (!(towerInfo.gameObject.activeInHierarchy || towerBuild.gameObject.activeInHierarchy) || Input.mousePosition.x < 1420);
    }
}
