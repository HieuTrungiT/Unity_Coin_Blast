using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Stage Config", menuName = "Create Stage Config")]
public class ConfigStage : ScriptableObject
{
    [SerializeField] List<GameObject> _listPfEnemys;
    [SerializeField] GameObject _PfBossEnemy;

    public int GetCountListEnemys()
    {
        return _listPfEnemys.Count;
    }
    public GameObject GetElementEnemy(int index)
    {
        return _listPfEnemys[index];
    }
    public GameObject GetBossEnemy()
    {
        return _PfBossEnemy;
    }
}
