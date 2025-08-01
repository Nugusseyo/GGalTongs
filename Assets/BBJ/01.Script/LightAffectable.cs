using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightAffectable : MonoBehaviour
{
    private int affectableLight;
    [SerializeField] private Light2D light;
    private void OnEnable()
    {
        ChackAffectableLight();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
        {
            affectableLight++;
            ChackAffectableLight();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
        {
            affectableLight--;
            ChackAffectableLight();
        }
    }
    private void ChackAffectableLight()
    {
        light.enabled = affectableLight > 0;
    }
    private void OnDisable()
    {
        affectableLight = 0;
        
    }
}
