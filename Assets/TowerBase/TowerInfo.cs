using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerInfo : MonoBehaviour
{
    public GameManager gameManager;
    public Image icon;
    public TMP_Text nameText;
    public TMP_Text upgradeDescription;
    public TMP_Text upgradeButtonText;
    public TMP_Text sellButtonText;

    private TowerBase target;

    public void SetTower(TowerBase towerBase)
    {
        gameObject.SetActive(true);
        target = towerBase;
        icon.sprite = towerBase.tower.icon;
        nameText.text = $"{towerBase.tower.towerName}\nLevel {towerBase.tower.level}";
        upgradeDescription.text = "?????????";
        upgradeButtonText.text = $"Upgrade\n{towerBase.tower.upgrade_cost}$";
        sellButtonText.text = $"Sell\n{towerBase.tower.sell_cost}$";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U)) TryUpgrade();
        if (Input.GetKeyDown(KeyCode.S)) Sell();
    }

    public void TryUpgrade()
    {
        if (gameManager.clear_energy_points >= target.tower.upgrade_cost)
        {
            gameManager.clear_energy_points -= target.tower.upgrade_cost;
            target.Upgrade();
            gameObject.SetActive(false);
        }
        SetTower(target);
    }

    public void Sell()
    {
        target.tower.Sell();
        gameObject.SetActive(false);
    }
}
