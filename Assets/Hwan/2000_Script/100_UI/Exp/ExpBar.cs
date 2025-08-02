using System;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    public RectTransform expBar;
    private float _targetRatio;

    public void GrowingExpBar()
    {
        _targetRatio = Mathf.Clamp01((float)ExpManager.Instance.currentExp / ExpManager.Instance.goalExp); // 0 ~ 1 사이로 제한
    }

    public void ResetExpBar()
    {
        _targetRatio = 0;
    }

    private void Update()
    {
        float currentWidth = expBar.sizeDelta.x;
        float targetWidth = 2000 * _targetRatio;

        float smoothedWidth = Mathf.Lerp(currentWidth, targetWidth, Time.deltaTime * 10f);
        
        Vector2 size = expBar.sizeDelta;
        size.x = smoothedWidth;
        expBar.sizeDelta = size;
    }
}
