
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectManager : MonoBehaviour
{
    public static SelectManager Instance { get; private set; }

    public Action StartSelect;

    [SerializeField] private GameObject selectUI;
    private SetCard setCard;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        StartSelect += OpenUI;

        setCard = selectUI.GetComponent<SetCard>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.T))
        {
            StartSelect?.Invoke();
        }
    }

    private void OpenUI()
    {
        setCard.AnimatorInter(false);
        selectUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseUI()
    {
        selectUI.SetActive(false);
        Time.timeScale = 1;
    }
}

