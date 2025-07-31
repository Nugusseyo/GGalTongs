using UnityEngine;
using UnityEngine.InputSystem;

public class SlotManage : MonoBehaviour
{
    [SerializeField] private GameObject torchPrefab;
    private void Update()
    {
        if(Keyboard.current.eKey.wasPressedThisFrame)
        {
            if(Slot.SelectSlot != null)
            {
               GameObject torch = Instantiate(torchPrefab, Slot.SelectSlot.transform.position, Quaternion.identity);
                if (torch.TryGetComponent(out Torch torchcompo))
                {
                    torchcompo.SetSlot(Slot.SelectSlot);
                }
            }
        }
    }
}
