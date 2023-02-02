using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Manager stage config", menuName = "Create manager stage config")]
public class ConfigManagerStage : ScriptableObject
{
    [SerializeField] List<ConfigStage> _listConfigStages;

    public int GetCountListStage()
    {
        return _listConfigStages.Count;
    }

    public ConfigStage GetElementConfigStage(int index)
    {
        return _listConfigStages[index];
    }
}
