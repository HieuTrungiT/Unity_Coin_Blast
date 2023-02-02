using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [Header("Line Enemy")]
    [SerializeField] int _lineEnemyBlueLevel_1;
    [SerializeField] int _lineEnemyGreenLevel_2;
    [SerializeField] int _lineEnemyOrangeLevel_3;

    [Header("Line Enemy Boss")]
    [SerializeField] int _lineEnemyMiniBoss;
    [SerializeField] int _lineEnemyBoss;
    [SerializeField] int _lineShield;
    [Header("Stage")]
    [SerializeField] int _currentPositionStage = 1;
    [SerializeField] int _currentPositionLevel = 1;
    [SerializeField] List<ConfigManagerStage> _listConfigManagerStages;

    public int GetCurentPositonStage()
    {
        return _currentPositionStage;
    }
    public void SetPromotionCurentPositonStage()
    {
        _currentPositionStage += 1;
    }

    public int GetCurentPositonLevel()
    {
        return _currentPositionLevel;
    }
    public void SetPromotionCurentPositonLevel()
    {
        _currentPositionLevel += 1;
    }
    public void SetDefauleCurentPositonLevel()
    {
        _currentPositionLevel = 0;
    }


    public int GetLineEnemy(int levelEnemy)
    {
        if (levelEnemy == 1)
        {
            return _lineEnemyBlueLevel_1;
        }
        else if (levelEnemy == 2)
        {
            return _lineEnemyGreenLevel_2;
        }
        else
        {
            return _lineEnemyOrangeLevel_3;
        }
    }
    public int GetLineEnemyMiniBoss()
    {
        return _lineEnemyMiniBoss;
    }
    public int GetLineEnemyBoss()
    {
        return _lineEnemyBoss;
    }
    public int GetLineShield()
    {
        return _lineShield;
    }
    public int GetCountManagerStage()
    {
        return _listConfigManagerStages.Count;
    }
    public ConfigManagerStage GetElementManagerStage(int index)
    {
        return _listConfigManagerStages[index];
    }

}
