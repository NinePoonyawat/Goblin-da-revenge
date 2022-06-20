using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelDescription : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private TMP_Text levelIndex, levelTitle, description;
    [SerializeField]
    private Button gameStartButton;

    private LevelDataSO levelData;

    void Awake()
    {
        gameStartButton.onClick.AddListener(startGame);
    }

    public void open(LevelDataSO data)
    {
        panel.SetActive(true);
        levelData = data;
        setText();
    }

    public void setText()
    {
        this.levelIndex.text = "Level : " + levelData.getLevel();
        this.levelTitle.text = levelData.getTitle();
        this.description.text = levelData.getDescription();
    }

    public void startGame()
    {
        SceneHandler.instance.Load(levelData.getTerminateSceneName());
    }
}
