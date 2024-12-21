using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TopUIController : MonoBehaviour
{
    public GameManager gameManager;
    public Slider hpBar;
    public TMP_Text cepText;
    public TMP_Text phaseText;
    public TMP_Text timerLabel;
    public TMP_Text timerText;

    void Start()
    {
        hpBar.maxValue = gameManager.earth_health;
    }

    void Update()
    {
        hpBar.value = gameManager.earth_health;
        cepText.text = gameManager.clean_energy_points.ToString();
        switch (gameManager.phase)
        {
            case 0:
                phaseText.text = "Prepare";
                timerLabel.text = $"Starts\nin{0}"; break;
            case 1:
                phaseText.text = "1st half";
                timerLabel.text = $"Next Phase\nin";
                timerText.text = $"{((int)(135 - gameManager.time) / 60).ToString("0")}:{((int)(135 - gameManager.time) % 60).ToString("00")}"; break;
            case 2:
                phaseText.text = "2nd half";
                timerLabel.text = $"Win\nin";
                timerText.text = $"{((int)(135 - gameManager.time) / 60).ToString("0")}:{((int)(135 - gameManager.time) % 60).ToString("00")}"; break;

        }
    }
}
