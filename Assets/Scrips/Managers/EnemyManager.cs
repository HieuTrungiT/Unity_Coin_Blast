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
    public int GetLineEnemyMiniBoss(){
        return _lineEnemyMiniBoss;
    }
    public int GetLineEnemyBoss(){
        return _lineEnemyBoss;
    }
}
