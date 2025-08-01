using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MoveStarter : MonoBehaviour
{
    public Action MoveStart { get; set; }

    private bool CanInput = false;

    private SetCard setCard;

    private void Awake()
    {
        setCard = GetComponent<SetCard>();
    }

    void Update()
    {
        if (CanInput == true && Input.GetKeyDown(KeyCode.Y))
        {
            MoveStart?.Invoke();

            CanInput = false;
        }
    }

    private void OnEnable()
    {
        StartCoroutine(ChangeCard());
    }

    private IEnumerator ChangeCard()
    {
        CanInput = true;
        MoveStart?.Invoke();
        yield return new WaitForSecondsRealtime(0.5f);
        setCard.ChooseCard();
    }
}
