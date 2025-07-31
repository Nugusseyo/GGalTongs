using System.Collections;
using TMPro;
using UnityEngine;

public class Torch : MonoBehaviour
{
    [SerializeField] private TextMeshPro lifeTimeText;
    [field: SerializeField] public float lifeTime { get; private set; }
    public Slot CurrentSlot { get; private set; }
    private void OnEnable()
    {
        StartCoroutine(LifeTime());
    }
    private IEnumerator LifeTime()
    {
        float timer = lifeTime;
        while(timer > 0)
        {
            timer -= Time.deltaTime;
            //SetLifeTimeText(timer);
            yield return null;
        }
        Destroy(gameObject);

    }
    private void SetLifeTimeText(float lifeTime)
    {
        lifeTimeText.text = $"{lifeTime / 60} : {lifeTime % 60}";
    }
    public void SetSlot(Slot slot)
    {
        if (CurrentSlot == null)
        {
            slot.SetActive(false);
            this.CurrentSlot = slot;

        }
    }
    private void OnDestroy()
    {
        if (CurrentSlot != null)
        {
            CurrentSlot.SetActive(true);
            this.CurrentSlot = null;
        }
    }
    

}
