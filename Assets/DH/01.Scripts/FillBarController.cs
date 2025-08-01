using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FillBarContoller : MonoBehaviour
{
    public static FillBarContoller Instance { get; private set; }

    [SerializeField] private Image fillImage; // Type = Filled로 설정된 UI Image
    [SerializeField] private float xpToLevel = 1f; // 한 레벨을 채우는 총 XP
    [SerializeField] private float fillSpeed = 1f; // 애니메이션 속도

    private float currentXP = 0f;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void AddXP(float amount)
    {
        StartCoroutine(AnimateAddXP(amount));
    }

    private IEnumerator AnimateAddXP(float amount)
    {
        float targetXP = currentXP + amount;

        while (currentXP < targetXP)
        {
            currentXP += Time.deltaTime * fillSpeed;
            if (currentXP > targetXP)
                currentXP = targetXP;

            UpdateUI();
            yield return null;
        }

        if (currentXP >= xpToLevel)
        {
            currentXP -= xpToLevel;
            OnLevelUp();
            UpdateUI();
        }
    }

    private void UpdateUI()
    {
        if (fillImage != null)
            fillImage.fillAmount = Mathf.Clamp01(currentXP / xpToLevel);
    }

    private void OnLevelUp()
    {
        Debug.Log("레벨업!"); // 레벨업 이펙트, 보상 등 처리
    }

    public void ResetXP()
    {
        currentXP = 0f;
        UpdateUI();
    }
}