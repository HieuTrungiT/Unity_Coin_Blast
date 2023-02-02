using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemys : MonoBehaviour
{
    EnemyManager myEnemyManager;

    Coroutine coroutine;
    Vector2 minBounds;
    Vector2 maxBounds;
    int _currentPositionStage;
    int _currentPositionLevel;
    int _countListConfigEnemysStage;
    bool _isBoss = false;
    bool _isLineBoss = false;
    int _countEnemys;
    private void Awake()
    {
        myEnemyManager = FindObjectOfType<EnemyManager>();

        _countListConfigEnemysStage = myEnemyManager.GetCountManagerStage();
    }
    private void Update()
    {

        if (_countEnemys == 0)
        {
            if (_isBoss)
            {
                if (!_isLineBoss)
                {
                    CreateStageEnemys();
                }
            }
            else
            {
                CreateStageEnemys();
            }
        }
    }
    private void Start()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
        CreateStageEnemys();
    }
    public void CreateStageEnemys()
    {
        _currentPositionStage = myEnemyManager.GetCurentPositonStage();

        if (_currentPositionStage <= _countListConfigEnemysStage)
        {
            ConfigManagerStage myConfigManagerStage = myEnemyManager.GetElementManagerStage(_currentPositionStage);
            CreateStageLevelEnemys(myConfigManagerStage);
        }
        else
        {
            Debug.Log("End Game");
        }
    }
    void CreateStageLevelEnemys(ConfigManagerStage _myConfigManagerStage)
    {
        _currentPositionLevel = myEnemyManager.GetCurentPositonLevel();
        ConfigStage myConfigStage = _myConfigManagerStage.GetElementConfigStage(_currentPositionLevel);
        coroutine = StartCoroutine(DelaySpawnEnemys(myConfigStage));

        if (_currentPositionLevel + 1 < _myConfigManagerStage.GetCountListStage())
        {
            myEnemyManager.SetPromotionCurentPositonLevel();
        }
        else
        {
            myEnemyManager.SetDefauleCurentPositonLevel();
            myEnemyManager.SetPromotionCurentPositonStage();
        }


    }

    IEnumerator DelaySpawnEnemys(ConfigStage _myConfigStage)
    {
        _countEnemys = _myConfigStage.GetCountListEnemys();

        for (int i = 0; i < _countEnemys; i++)
        {
            yield return new WaitForSeconds(1f);
            Instantiate(_myConfigStage.GetElementEnemy(i), new Vector2(Random.Range(minBounds.x, maxBounds.x), transform.position.y), Quaternion.identity);
        }
        if (_myConfigStage.GetBossEnemy() != null)
        {
            Instantiate(_myConfigStage.GetBossEnemy(), new Vector2(Random.Range(minBounds.x, maxBounds.x), transform.position.y), Quaternion.identity);
            _isLineBoss = true;
            _isBoss = true;
        }
    }

    void OnApplicationQuit()
    {
        StopCoroutine(coroutine);
    }
    public int GetCountEnemys()
    {
        return _countEnemys;
    }
    public void SetIsLineBoss()
    {
        _isLineBoss = false;
    }
    public void SetCountEnemy()
    {
        _countEnemys -= 1;

    }
}
