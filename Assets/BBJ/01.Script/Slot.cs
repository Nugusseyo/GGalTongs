using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField] private GameObject speechBubble;

    [SerializeField] private GameObject torchPrefab;
    public static Slot SelectSlot { get; private set; }
    private bool isThere;
    private void OnMouseEnter()
    {
        if(SelectSlot == null)
        {
            SelectSlot = this;
            speechBubble.SetActive(true);
            speechBubble.transform.position = transform.position;
        }
    }
    private void OnMouseExit()
    {
        if(SelectSlot == this)
        {
            SelectSlot = null;
            speechBubble.SetActive(false);
        }
    }
    public void InstallationTorch()
    {
        isThere = true;
        gameObject.SetActive(false);
        GameObject torch = Instantiate(torchPrefab, transform.position, Quaternion.identity);
        if (torch.TryGetComponent(out Torch torchcompo))
        {
            TorchItemUi.Instance.UseTorchItem(1);
            torchcompo.SetSlot(this);
        }
        OnMouseExit();
    }
    public void RemoveTorch()
    {
        isThere = false;
        CheckTorch();
    }
    private void CheckTorch()
    {
        if (!isThere)
            gameObject.SetActive(TorchItemUi.Instance?.CurretTorchItem > 0);
    }
    private void Start()
    {
        TorchItemUi.Instance.OnApplyCount += CheckTorch;
    }
    private void OnDestroy()
    {
        if(TorchItemUi.Instance != null)
        TorchItemUi.Instance.OnApplyCount -= CheckTorch;
    }
}
