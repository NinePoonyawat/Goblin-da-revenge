using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ExperienceSystem : ScriptableObject
{
    public int level;
    private int currentEXP;
    private int EXPtoNextLevel;

    void Awake()
    {
        level = 1;
    }

    void Start()
    {
        EXPtoNextLevel = level * 100;
    }

    public void addEXP(int addingEXP)
    {
        currentEXP += addingEXP;
        while (currentEXP >= EXPtoNextLevel)
        {
            currentEXP -= EXPtoNextLevel;
            levelUp();
            EXPtoNextLevel = level * 100;
        }
    }

    public void levelUp()
    {
        level += 1;
    }
}
