using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyData : ScriptableObject
{
    [SerializeField]
    private string enemyName;
    [SerializeField]
    private EnemyRace race;
    [SerializeField]
    private int EXPAfterKilled;

    public string getName()
    {
        return enemyName;
    }

    public EnemyRace getRace()
    {
        return race;
    }

    public int getEXPAfterKilled()
    {
        return EXPAfterKilled;
    }
}

public enum EnemyRace
{
    Human,
    Demon
}