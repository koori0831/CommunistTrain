using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
    }

    public void EnterScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
