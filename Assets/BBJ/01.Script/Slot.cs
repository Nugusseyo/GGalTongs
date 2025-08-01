using UnityEngine;

public class Slot : MonoBehaviour
{
    [Header("Prefab")]
    [SerializeField] private GameObject torchPrefab;
    [Header("SoundCilp")]
    [SerializeField] private AudioClip[] installationClips;
    [SerializeField] private AudioClip[] removeClips;
    public static Slot SelectSlot { get; private set; }
    private bool isThere;
    private AudioSource source;
    private void Start()
    {
        source = GetComponentInParent<AudioSource>();
        TorchItemUi.Instance.OnApplyCount += CheckTorch;
    }
    private void OnMouseEnter()
    {
        if(SelectSlot == null)
        {
            SelectSlot = this;
            SlotManage.Instance.SpeechBubble.SetActive(true);
            SlotManage.Instance.SpeechBubble.transform.position = transform.position;
        }
    }
    private void OnMouseExit()
    {
        if(SelectSlot == this)
        {
            SelectSlot = null;
            SlotManage.Instance.SpeechBubble.SetActive(false);
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
        SoundPlay(installationClips);
        OnMouseExit();
    }

    private void SoundPlay(AudioClip[] clips)
    {
        source.clip = clips[Random.Range(0, clips.Length)];
        source.Play();
    }

    public void RemoveTorch()
    {
        isThere = false;
        CheckTorch();
        SoundPlay(removeClips);
    }
    private void CheckTorch()
    {
        if (!isThere)
            gameObject.SetActive(TorchItemUi.Instance?.CurretTorchItem > 0);
    }
    private void OnDestroy()
    {
        if(TorchItemUi.Instance != null)
        TorchItemUi.Instance.OnApplyCount -= CheckTorch;
    }
}
