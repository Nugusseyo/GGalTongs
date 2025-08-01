using System;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Random = UnityEngine.Random;

public class DyingMessages : MonoBehaviour
{
    public PlayerInputSO playerInput;
    
    public TextMeshProUGUI messageText;
    public TextMeshProUGUI messageText2;
    public DyingSO dyingMessages;
    

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        float score = 0;
        if (ScoreManager.Instance != null)
        {
            score =  ScoreManager.Instance.killCount;
        }
        messageText.text =
            $"<Tip>\n{dyingMessages.MessageList[Random.Range(0, dyingMessages.MessageList.Count)].Messages}";
        messageText2.text = $"처치 수 : {score}\n";
        if (score > PlayerPrefs.GetInt("killCount"))
        {
            PlayerPrefs.SetInt("killCount", (int)score);
            messageText2.text += "갱신된 ";
        }

        messageText2.text += $"최다 처치 수 : {PlayerPrefs.GetInt("killCount")}";
        playerInput.isGamePaused = true;
        Time.timeScale = 0f;
    }

    private void OnDisable()
    {
        playerInput.isGamePaused = false;
        Time.timeScale = 1f;
    }
}
