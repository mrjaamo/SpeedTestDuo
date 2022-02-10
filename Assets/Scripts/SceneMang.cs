using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMang : MonoBehaviour
{
    public string SceneName;
    
    public void LoadScene()
    {
        SceneManager.LoadSceneAsync(SceneName);
    }
}
