using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBarUI : MonoBehaviour
{
    [SerializeField] private Image fillImage;

    public void SetFill(float ratio)
    {
        fillImage.fillAmount = Mathf.Clamp01(ratio);
    }
}
