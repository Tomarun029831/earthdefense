using UnityEngine;
using UnityEngine.UI;

public class HPBarController : MonoBehaviour
{
    [SerializeField] private Image hpFillImage; // 前景のImageコンポーネント
    [SerializeField] private Color fullHPColor = Color.green; // HPが高いときの色
    [SerializeField] private Color lowHPColor = Color.red; // HPが低いときの色
    private float maxHP = 100f; // 最大HP
    private static float currentHP = 100f; // 現在のHP
    private float displayedHP; // 表示用HP

    [SerializeField] private float smoothSpeed = 5f; // 滑らかさの速度
    [SerializeField] private float colorThreshold = 0.3f; // 色が変わる閾値

    void Start()
    {
        currentHP = maxHP; // 初期化
        displayedHP = currentHP; // 表示用HPを初期化
        UpdateHPBar(); // 初期状態でバーを更新
    }

    void Update()
    {
        // 表示用HPを滑らかに更新
        displayedHP = Mathf.Lerp(displayedHP, currentHP, Time.deltaTime * smoothSpeed);

        // HPバーの更新
        UpdateHPBar();

        // デバッグ用: HP操作
        if (Input.GetKeyDown(KeyCode.Space)) // スペースキーでダメージ
        {
            TakeDamage(10);
        }

        if (Input.GetKeyDown(KeyCode.H)) // Hキーで回復
        {
            Heal(10);
        }
    }

    // ダメージを受けたときの処理
    public void TakeDamage(float damage)
    {
        currentHP -= damage; // HPを減少
        currentHP = Mathf.Clamp(currentHP, 0, maxHP); // 範囲内に制限
    }

    // 回復時の処理
    public void Heal(float healAmount)
    {
        currentHP += healAmount; // HPを増加
        currentHP = Mathf.Clamp(currentHP, 0, maxHP); // 範囲内に制限
    }

    // HPバーを更新するメソッド
    private void UpdateHPBar()
    {
        if (hpFillImage != null)
        {
            // HP割合を計算
            float fillAmount = displayedHP / maxHP;

            // HPバーのフィル量を更新
            hpFillImage.fillAmount = fillAmount;

            // HP割合に応じて色を変更
            if (fillAmount <= colorThreshold)
            {
                hpFillImage.color = lowHPColor; // 赤色
            }
            else
            {
                hpFillImage.color = fullHPColor; // 緑色
            }
        }
    }

    // 現在のHPを取得するメソッド
    public static float GetCurrentHP()
    {
        return currentHP;
    }
}
