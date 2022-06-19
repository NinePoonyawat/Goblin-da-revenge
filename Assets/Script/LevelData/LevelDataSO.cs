using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelDataSO : ScriptableObject
{
    [SerializeField]
    private int chapter,level;
    [SerializeField]
    private string levelTitle;
    [SerializeField]
    [TextArea]
    private string levelDescription;

    [SerializeField]
    private string terminateSceneName;

    private LevelState levelState = LevelState.Locked;

    public string getTerminateSceneName()
    {
        return terminateSceneName;
    }

    public enum LevelState
    {
        Locked,
        Passed,
        Current
    }
}
