using UnityEngine;
using UnityEngine.Events;

public class ExpManager : MonoBehaviour
{
    public static ExpManager Instance; 
    [SerializeField] private ExpBar expBar;
    public int CurrentLevel { get; private set; }
    public int currentExp;
    public int goalExp;

    public UnityEvent levelUp;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
        }
        CurrentLevel = 0;
        currentExp = 0;
        goalExp = 10;

        expBar = GetComponentInChildren<ExpBar>();
    }

    public void ExpUp(int value)
    {
        currentExp += value;
        expBar.GrowingExpBar();
        if (currentExp < goalExp) return;
        Debug.Log("넘어갔따");
        goalExp = 10 * (CurrentLevel + 1);
        CurrentLevel++;
        currentExp = 0;
        float ran = Random.Range(0, 10);
        if(ran == 4) {TorchItemUi.Instance.AddTorchItme(1);}
        levelUp?.Invoke();
    }
}
