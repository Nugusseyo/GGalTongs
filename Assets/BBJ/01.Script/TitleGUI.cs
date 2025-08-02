using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleGUI : MonoBehaviour
{
    [SerializeField] private GameObject settingGUI;

    private void Awake()
    {
        settingGUI.SetActive(false);
    }

    public void OnEnd()
    {
        Application.Quit();
    }
    public void OnSettingUI()
    {
        settingGUI.SetActive(!settingGUI.activeSelf);
    }
    public void StartIngame()
    {
        SceneManager.LoadScene("MergeScene");
    }
}
