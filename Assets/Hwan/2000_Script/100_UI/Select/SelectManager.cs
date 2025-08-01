
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectManager : MonoBehaviour
{
    public static SelectManager Instance { get; private set; }

    public Action StartSelect;

    [SerializeField] private GameObject selectUI;

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
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            StartSelect?.Invoke();
        }
    }

    private void OpenUI()
    {
        selectUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseUI()
    {
        selectUI.SetActive(true);
        Time.timeScale = 1;
    }
}

