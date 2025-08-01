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

    private void OnEnable()
    {
        ChangeCard();
    }

    private void ChangeCard()
    {
        CanInput = true;
        MoveStart?.Invoke();
        setCard.ChooseCard();
    }
}
