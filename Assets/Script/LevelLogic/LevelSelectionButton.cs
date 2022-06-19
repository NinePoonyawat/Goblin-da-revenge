using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class LevelSelectionButton : MonoBehaviour
{
    [SerializeField]
    private LevelDataSO levelData;

    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = gameObject.GetComponent<Button>();

        button.onClick.AddListener(startGame);
    }

    void startGame()
    {
        SceneHandler.instance.Load(levelData.getTerminateSceneName());
    }
}
