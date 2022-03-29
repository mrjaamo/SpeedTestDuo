using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMang : MonoBehaviour
{

    public GameObject AndroidMenu, PCMenu;

    void Start()
    {
        if(Application.isMobilePlatform){
            AndroidMenu.SetActive(true);
            PCMenu.SetActive(false);
        }else{
            AndroidMenu.SetActive(false);
            PCMenu.SetActive(true);
        }
    }

    public void LoadScene(string SceneName)
    {
        SceneManager.LoadSceneAsync(SceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}