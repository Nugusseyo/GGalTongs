
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

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

    private void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            OpenUI();
        }
    }

    public void OpenUI()
    {
        if (Time.timeScale != 0)
        {
            setCard.ButtonInter(false);
            selectUI.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void CloseUI()
    {
        selectUI.SetActive(false);
        Time.timeScale = 1;
    }
}

