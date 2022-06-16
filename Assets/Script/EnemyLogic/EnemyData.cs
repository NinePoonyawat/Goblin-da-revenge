using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    [SerializeField]
    private string enemyName;

    [SerializeField]
    private enemyRace race;

    public bool isRace(enemyRace compareRace)
    {
        return race == compareRace;
    }

    public string getEnemyName()
    {
        return enemyName;
    }

    public enemyRace getRace()
    {
        return race;
    }

    public enum enemyRace
    {
        Human,
        Demon
    }
}
