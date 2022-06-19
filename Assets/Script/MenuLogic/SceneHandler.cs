using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public static SceneHandler instance{set;get;}
    
    private void Awake()
    {
        Debug.Log("I'm wakeup");
        instance = this;
    }

    public void Load(string sceneName)
    {
        Debug.Log("enter");
        if(!SceneManager.GetSceneByName(sceneName).isLoaded)
        {
            SceneManager.LoadSceneAsync(sceneName,LoadSceneMode.Single);
        }
    }

    public void UnLoadActiveScene()
    {
        Unload(SceneManager.GetActiveScene().name);
    }

    public void Unload(string sceneName)
    {
        if(SceneManager.GetSceneByName(sceneName).isLoaded)
        {
            SceneManager.UnloadSceneAsync(sceneName);
        }
    }
}
