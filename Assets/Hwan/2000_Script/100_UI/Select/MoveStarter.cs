using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MoveStarter : MonoBehaviour
{
    public Action MoveStart { get; set; }

    private SetCard setCard;

    private bool isFirst = true;

    private void Awake()
    {
        setCard = GetComponent<SetCard>();
    }

    private void OnEnable()
    {
        if (!isFirst)
        {
            ChangeCard();
        }
        else
        {
            isFirst = false;
        }
    }

    private void ChangeCard()
    {
        MoveStart?.Invoke();
        setCard.ChooseCard();
    }
}
