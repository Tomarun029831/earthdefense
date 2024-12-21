using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{   
    public float timeRemaining = 121f;
    public Text timerText;
    public Color defaultColor = Color.white;
    public Color alertColor = Color.red;
    private bool isCountingDown = true;

    void Start()
    {
        if (timerText == null)
        {
            Debug.LogError("timerTextが設定されていません。Inspectorで設定してください。");
        }
    }

    void Update()
    {
        if (isCountingDown)
        {
            if (timeRemaining > 1)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerText();
            }
            else
            {
                timeRemaining = 1;
                isCountingDown = false;
                TimerEnded();
            }
        }
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = $"{minutes:0}:{seconds:00}";

        // 時間が30秒未満の場合、色を変更
        if (timeRemaining < 30)
        {
            timerText.color = Color.Lerp(timerText.color, alertColor, Time.deltaTime * 5);
        }
        else
        {
            timerText.color = defaultColor;
        }
    }

    void TimerEnded()
    {
        Debug.Log("end");
    }
}
