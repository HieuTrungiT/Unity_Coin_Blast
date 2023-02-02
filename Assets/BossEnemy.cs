using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    EnemyManager myEnemyManager;
    CreateEnemys myCreateEnemy;

    int lineBoss = 0;
    bool isLineShield = true;
    private void Awake()
    {
        myEnemyManager = FindObjectOfType<EnemyManager>();
        myCreateEnemy = FindObjectOfType<CreateEnemys>();
        lineBoss = myEnemyManager.GetLineEnemyBoss();
    }
    private void Update()
    {
        if (lineBoss == 0)
        {
            lineBoss -= 1;
            StartCoroutine(DelayDestroyBoss());
        }
    }
    IEnumerator DelayDestroyBoss()
    {
        gameObject.AddComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));

        yield return new WaitForSeconds(2f);
        myCreateEnemy.SetIsLineBoss();
        Destroy(gameObject);
    }
    public void SetLineBoss()
    {
        lineBoss -= 1;
    }

}
