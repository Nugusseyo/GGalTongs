using UnityEngine;

public class CameraLetterbox : MonoBehaviour
{
    [SerializeField] private float targetAspect = 16f / 9f;

    private void Start()
    {
        float windowAspect = (float)Screen.width / Screen.height;
        float scaleHeight = windowAspect / targetAspect;

        Camera cam = GetComponent<Camera>();

        if (scaleHeight < 1f)
        {
            // ���Ʒ��� ���͹ڽ� (������)
            Rect rect = cam.rect;

            rect.width = 1f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1f - scaleHeight) / 2f;

            cam.rect = rect;
        }
        else
        {
            // �¿쿡 ���͹ڽ�
            float scaleWidth = 1f / scaleHeight;

            Rect rect = cam.rect;

            rect.width = scaleWidth;
            rect.height = 1f;
            rect.x = (1f - scaleWidth) / 2f;
            rect.y = 0;

            cam.rect = rect;
        }
    }
}
