using UnityEngine;
using UnityEngine.InputSystem;

public class SlotManage : MonoBehaviour
{
    public static SlotManage Instance { get; private set; }

    [field: SerializeField] public GameObject SpeechBubble { get; private set; }

    [field: SerializeField] public float LightRadius { get; set; }
    [field: SerializeField] public float lifeTime { get; set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Update()
    {
        if (TorchItemUi.Instance.CurretTorchItem <= 0) return;

        if(Keyboard.current.eKey.wasPressedThisFrame)
        {
            if(Slot.SelectSlot != null)
            {
                Slot.SelectSlot.InstallationTorch();
            }
        }
    }
    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
}
