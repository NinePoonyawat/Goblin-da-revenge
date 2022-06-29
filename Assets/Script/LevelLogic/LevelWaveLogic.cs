using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelWaveLogic : MonoBehaviour
{
    [SerializeField]
    private WaveObstacle[] gameWave;

    private List<GameObject> waveObstacle;

    private int allWaveNumber;
    private int waveNumber = 1;

    [SerializeField]
    private GameWaveStatus gameWaveStatus = GameWaveStatus.ONGOING;
    // Start is called before the first frame update
    void Awake()
    {
        allWaveNumber = gameWave.Length;
    }

    void Start()
    {
        switch (gameWaveStatus)
        {
            case GameWaveStatus.ONGOING:
                waveNumber = 0;
                waveObstacle = gameWave[0].allObstacleInWave;
                break;
            default:
                waveNumber = -1;
                break;
        }  
    }

    // Update is called once per frame
    void Update()
    {
        if (gameWaveStatus == GameWaveStatus.FLEE)
            return;
        if (gameWaveStatus == GameWaveStatus.ONGOING)
        {
            for (int i = waveObstacle.Count - 1 ; i >= 0 ; i--)
            {
                try
                {
                    GameObject obstacle = waveObstacle[i];
                    IWaveObstacle waveObstacleObject = obstacle.GetComponent<IWaveObstacle>();
                    if (!waveObstacleObject.getIsWaveStacle())
                    {
                        waveObstacle.Remove(obstacle);
                    }
                    if (waveObstacleObject.getIsWaveStacle())
                    {
                        return;
                    }
                }
                catch (MissingReferenceException)
                {
                    waveObstacle.RemoveAt(i);
                }
            }
            gameWaveStatus = GameWaveStatus.FLEE;
        }
    }

    public void addNewWaveObstacle(GameObject GO)
    {
        waveObstacle.Add(GO);
    }

    public void startNextWave()
    {
        waveNumber += 1;
        waveObstacle = gameWave[waveNumber].allObstacleInWave;
        gameWaveStatus = GameWaveStatus.ONGOING;
        foreach (var obstacle in waveObstacle)
        {
            obstacle.SetActive(true);
        }
    }

    [Serializable]
    public struct WaveObstacle
    {
        public List<GameObject> allObstacleInWave;
    }

    public enum GameWaveStatus
    {
        ONGOING,
        FLEE
    }
}
