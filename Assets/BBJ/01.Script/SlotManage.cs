using UnityEngine;
using UnityEngine.InputSystem;

public class SlotManage : MonoBehaviour
{
    [SerializeField] private GameObject torchPrefab;
    private void Update()
    {
        if (TorchUi.Instance.TorchCount < 0) return;

        if(Keyboard.current.eKey.wasPressedThisFrame)
        {
            if(Slot.SelectSlot != null)
            {
               GameObject torch = Instantiate(torchPrefab, Slot.SelectSlot.transform.position, Quaternion.identity);
                if (torch.TryGetComponent(out Torch torchcompo))
                {
                    TorchUi.Instance.UseTorch(1);
                    torchcompo.SetSlot(Slot.SelectSlot);
                }
            }
        }
    }
}
