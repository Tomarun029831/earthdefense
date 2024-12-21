using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerBuild : MonoBehaviour
{
    public GameManager gameManager;
    private TowerBase target;
    public void SetBase(TowerBase _towerBase)
    {
        target = _towerBase;
        gameObject.SetActive(true);
    }

    public void TryBuild(Tower tower)
    {
        if (tower.build_cost <= gameManager.clear_energy_points)
        {
            gameManager.clear_energy_points -= tower.build_cost;
            target.Build(tower.gameObject);
            gameObject.SetActive(false);
        }
    }
}
