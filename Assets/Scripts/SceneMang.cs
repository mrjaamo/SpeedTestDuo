using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMang : MonoBehaviour
{
   public void LoadScene(string SceneName)
    {
        SceneManager.LoadSceneAsync(SceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
