using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleGUI : MonoBehaviour
{
    [SerializeField] private GameObject settingGUI;
    public void OnEnd()
    {
        Application.Quit();
    }
    public void OnSettingUI()
    {
        settingGUI.SetActive(true);
    }
    public void StartIngame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
