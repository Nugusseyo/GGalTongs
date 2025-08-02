using System;
using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MoveStarter : MonoBehaviour
{
    public Action MoveStart { get; set; }

    private SetCard setCard;

    private bool isFirst = true;

    private AudioSource _audio;
    [SerializeField] private AudioClip _clip;

    private void Awake()
    {
        setCard = GetComponent<SetCard>();
        _audio = GetComponent<AudioSource>();
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
        _audio.PlayOneShot(_clip);
        MoveStart?.Invoke();
        setCard.ChooseCard();
    }
}
