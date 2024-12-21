using UnityEngine;
using UnityEngine.UI;

public class HPFlashEffect : MonoBehaviour
{
    public float maxHP = 100f; // 最大HP
    public float currentHP = 100f; // 現在のHP
    public float lowHPThreshold = 30f; // 点滅を開始するHPの閾値
    public float flashSpeed = 2f; // 点滅の速度
    public Image flashImage; // 画面全体を覆うImage

    private bool isFlashing = false;

    void Update()
    {
        // HPが閾値以下の場合に点滅を開始
        if (currentHP <= lowHPThreshold)
        {
            if (!isFlashing)
            {
                isFlashing = true;
                StartCoroutine(FlashEffect());
            }
        }
        else
        {
            isFlashing = false;
            StopAllCoroutines();
            if (flashImage != null)
                flashImage.color = new Color(255, 255, 255, 0); // アルファを0に
        }
    }

    private System.Collections.IEnumerator FlashEffect()
    {
        while (isFlashing)
        {
            if (flashImage != null)
            {
                // アルファ値を繰り返し変化させる
                float alpha = Mathf.Abs(Mathf.Sin(Time.time * flashSpeed));
                flashImage.color = new Color(1, 1, 1, alpha);
            }
            yield return null;
        }
    }
}
