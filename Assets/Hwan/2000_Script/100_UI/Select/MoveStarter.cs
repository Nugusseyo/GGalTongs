using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MoveStarter : MonoBehaviour
{
    public Action MoveStart { get; set; }

    public bool CanInput = false;

    private SetCard setCard;

    private int count = 0;

    private void Awake()
    {
        setCard = GetComponent<SetCard>();
    }

    void Update()
    {
        if (CanInput == true && Input.GetKeyDown(KeyCode.Y))
        {
            MoveStart?.Invoke();
            count++;
            if (count <= 1)
            {
                StartCoroutine(ChangeCard());
            }
            if (count >= 2)
            {
                CanInput = false;
            }
        }
    }

    private void OnEnable()
    {
        CanInput = true;
    }

    private IEnumerator ChangeCard()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        setCard.ChooseCard();
    }
}
