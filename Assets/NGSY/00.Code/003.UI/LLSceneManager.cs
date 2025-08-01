using UnityEngine;
using UnityEngine.SceneManagement;

public class LLSceneManager : MonoBehaviour
{
    public void GoToTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void Retry()
    {
        SceneManager.LoadScene("MergeScene");
    }
}
