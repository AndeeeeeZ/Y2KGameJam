using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string nextSceneName;

    public void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName, LoadSceneMode.Single);
    }

    public void LoadSceneWithName(string name)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }
}
