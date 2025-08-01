using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleGUI : MonoBehaviour
{
    [SerializeField] private GameObject settingGUI;
    private void OnEnd()
    {
        Application.Quit();
    }
    private void OnSettingUI()
    {
        settingGUI.SetActive(true);
    }
    private void StartIngame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
