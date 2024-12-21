using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class _Tower : MonoBehaviour
{
    [SerializeField]
    public string towerName;
    [SerializeField]
    public Sprite icon;
    [SerializeField]
    public int level;
    [SerializeField]
    public GameObject CO2PF;
    [SerializeField]
    public Transform enemyParent;
    [SerializeField]
    public float absorbInterval;
    [SerializeField]
    public float absorbableSqrDistance;
    [SerializeField]
    public int upgradeCost;
    [SerializeField]
    public int price;
    public float absorbTimer = 0;

    void Update()
    {
        absorbTimer -= Time.deltaTime;
        if (absorbTimer < 0)
        {
            absorbTimer = absorbInterval;
            Enemy target = Findtarget();
            if (target == null) return;
            GameObject co2 = Instantiate(CO2PF, target.transform.position, Quaternion.identity);
            co2.GetComponent<CO2>().target = transform.position;
            target.current_health--;
        }
    }

    public void Upgrade()
    {
        Debug.Log("Upgraded");
    }

    public int Sell()
    {
        Destroy(gameObject);
        return price / 2;
    }

    private Enemy Findtarget()
    {
        Enemy target = null;
        float targetPathPos = 0;
        for (int i = 0; i < enemyParent.childCount; i++)
        {
            Transform enemy = enemyParent.GetChild(i);
            if (enemy == null) continue;
            float enemyPathPos = enemy.GetComponent<CinemachineDollyCart>().m_Position;
            if ((transform.position - enemy.position).sqrMagnitude < absorbableSqrDistance && targetPathPos < enemyPathPos)
            {
                target = enemy.GetComponent<Enemy>();
                targetPathPos = enemyPathPos;
            }
        }
        return target;
    }
}
