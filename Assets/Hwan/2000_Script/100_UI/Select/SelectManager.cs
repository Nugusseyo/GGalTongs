using UnityEngine;

public class SelectManager : MonoBehaviour
{
    public static SelectManager Instance { get; private set; }

    [SerializeField] private GameObject selectUI;
    private SetCard setCard;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        setCard = selectUI.GetComponent<SetCard>();
    }

    public void OpenUI()
    {
        if (Time.timeScale != 0)
        {
            PlayerInputManager.Instance.StopAllInputs();
            setCard.ButtonInter(false);
            selectUI.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void CloseUI()
    {
        PlayerInputManager.Instance.AcceptAllInputs();
        selectUI.SetActive(false);
        Time.timeScale = 1;
    }
}

