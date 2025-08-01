using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ExperienceBarController : MonoBehaviour
{
    [SerializeField] private Image fillImage; // Image.Type이 Filled여야 함
    [SerializeField] private float xpToLevel = 100f;
    [SerializeField] private float baseAnimationDuration = 0.5f; // 기본 애니메이션 시간 (한 번에 들어오는 xp 양에 비례해서 조정)

    private float currentXP = 0f;       // 실제로 쌓인 XP (목표)
    private float displayedXP = 0f;     // UI에 보여주는 XP (애니메이션 중)
    private bool isAnimating = false;

    public void AddXP(float amount)
    {
        if (xpToLevel <= 0f) return;

        // 목표 XP 누적 (오버플로우 방지)
        float newTarget = Mathf.Min(currentXP + amount, xpToLevel);
        float deltaXP = newTarget - currentXP;
        if (deltaXP <= 0f) return; // 이미 가득 찼거나 줄어들 여지 없음

        currentXP = newTarget;

        // 애니메이션 시작 (이미 돌고 있으면 coroutine이 내부적으로 목표를 따라잡음)
        if (!isAnimating)
        {
            StartCoroutine(AnimateXP());
        }
    }

    private IEnumerator AnimateXP()
    {
        isAnimating = true;

        while (!Mathf.Approximately(displayedXP, currentXP))
        {
            float xpDifference = Mathf.Abs(currentXP - displayedXP);
            if (xpDifference < 0.001f)
            {
                displayedXP = currentXP;
            }
            else
            {
                // 애니메이션 시간을 xpDifference 비중에 따라 조정 (작은 변화면 짧게, 큰 변화면 길게)
                float t = Mathf.Clamp01(Time.deltaTime / baseAnimationDuration * (xpToLevel / xpDifference));
                displayedXP = Mathf.MoveTowards(displayedXP, currentXP, xpToLevel * t);
            }

            UpdateUI();

            yield return null;
        }

        displayedXP = currentXP; // 정밀하게 맞춤
        UpdateUI();

        isAnimating = false;
    }

    private void UpdateUI()
    {
        if (fillImage != null && xpToLevel > 0f)
        {
            float fraction = Mathf.Clamp01(displayedXP / xpToLevel);
            fillImage.fillAmount = fraction;
        }
    }
}
