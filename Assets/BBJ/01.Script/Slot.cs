using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField] private GameObject speechBubble;
    public static Slot SelectSlot { get; private set; }

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
    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
        if(!isActive)
            OnMouseExit();
    }
}
