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

    private LevelState levelState = LevelState.Locked;

    public enum LevelState
    {
        Locked,
        Passed,
        Current
    }
}
