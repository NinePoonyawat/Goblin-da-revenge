using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class LevelSelectionButton : MonoBehaviour
{
    [SerializeField]
    private LevelDataSO levelData;

    public Button button;
    private Image image;
    [SerializeField]
    private TMP_Text levelText;

    private LevelDescription levelDescription;

    // Start is called before the first frame update
    void Start()
    {
        button = gameObject.GetComponent<Button>();
        image = gameObject.GetComponent<Image>();

        button.onClick.AddListener(openLevelDesctiption);

        LevelState state = levelData.getLevelState();
        switch (state)
        {
            case LevelState.Locked:
                image.color = Color.red;
                break;
            case LevelState.Current:
                image.color = Color.yellow;
                break;
            case LevelState.Passed:
                image.color = Color.green;
                break;
        }
        levelText.text = "" + levelData.getLevel();
        levelDescription = GameObject.Find("Canvas").GetComponent<LevelDescription>();
    }

    void openLevelDesctiption()
    {
        levelDescription.open(levelData);
    }
}
