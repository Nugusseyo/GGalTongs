using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Torch : MonoBehaviour
{
    [SerializeField] private float lightRadius => SlotManage.Instance.LightRadius;
    [SerializeField] private float lifeTime => SlotManage.Instance.lifeTime;
    [SerializeField] private TextMeshPro lifeTimeText;
    [SerializeField] private CircleCollider2D lightBoundary;
    
    private Light2D light;
    public Slot CurrentSlot { get; private set; }
    private void Awake()
    {
        light = GetComponentInChildren<Light2D>();
    }
    private void OnEnable()
    {
        light.pointLightOuterRadius = lightRadius;
        lightBoundary.radius = lightRadius;
        StartCoroutine(LifeTime());
    }
    private IEnumerator LifeTime()
    {
        float timer = lifeTime;
        while(timer > 0)
        {
            timer -= Time.deltaTime;
            if(timer < 10)
            {
                light.pointLightOuterRadius -= 0.1f * Time.deltaTime;
            }
            SetLifeTimeText(timer);
            yield return null;
        }
        Destroy(gameObject);

    }
    private void SetLifeTimeText(float lifeTime)
    {
        lifeTimeText.text = $"{(int)Mathf.Round(lifeTime) / 60}:{Mathf.Round(lifeTime) % 60}";
    }
    public void SetSlot(Slot slot)
    {
        if (CurrentSlot == null)
        {
            this.CurrentSlot = slot;

        }
    }
    private void OnDestroy()
    {
        if (CurrentSlot != null)
        {
            CurrentSlot.RemoveTorch();
            this.CurrentSlot = null;
        }
    }
    

}
