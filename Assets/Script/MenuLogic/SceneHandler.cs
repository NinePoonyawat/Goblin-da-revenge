using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public static SceneHandler instance{set;get;}
    
    private void Awake()
    {
        if (instance != null & instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void Load(string sceneName)
    {
        if(!SceneManager.GetSceneByName(sceneName).isLoaded)
        {
            StartCoroutine(LoadAsync(sceneName));
        }
    }

    public void Unload(string sceneName)
    {
        if(SceneManager.GetSceneByName(sceneName).isLoaded)
        {
            SceneManager.UnloadSceneAsync(sceneName);
        }
    }

    IEnumerator LoadAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName,LoadSceneMode.Single);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            Debug.Log(operation.progress);

            yield return null;
        }
    }
}
