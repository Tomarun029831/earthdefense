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

    private Tower target;

    public void SetTower(Tower tower)
    {
        gameObject.SetActive(true);
        target = tower;
        icon.sprite = tower.icon;
        nameText.text = $"{tower.towerName}\nLevel {tower.level}";
        upgradeDescription.text = "?????????";
        upgradeButtonText.text = $"Upgrade\n{tower.upgrade_cost}$";
        sellButtonText.text = $"Sell\n{tower.sell_cost}$";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U)) TryUpgrade();
        if (Input.GetKeyDown(KeyCode.S)) Sell();
    }

    public void TryUpgrade()
    {
        if (gameManager.clear_energy_points >= target.upgrade_cost)
        {
            gameManager.clear_energy_points -= target.upgrade_cost;
            target.Upgrade();
            gameObject.SetActive(false);
        }
        SetTower(target);
    }

    public void Sell()
    {
        target.Sell();
        gameObject.SetActive(false);
    }
}
