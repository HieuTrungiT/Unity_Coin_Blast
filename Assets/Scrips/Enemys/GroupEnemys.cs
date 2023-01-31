using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupEnemys : MonoBehaviour
{
    [SerializeField] GameObject _enemyMiniBoss;
    EnemyMiniBoss _thisEnemyMiniBoss;
    bool _isDestroyEnemyGroup = false;
    private void Awake()
    {
        _thisEnemyMiniBoss = _enemyMiniBoss.GetComponent<EnemyMiniBoss>();
    }

    private void Update()
    {



        if (_thisEnemyMiniBoss.GetLineThisMiniBoss() <= 0 && !_isDestroyEnemyGroup)
        {
            _isDestroyEnemyGroup = true;
            StartCoroutine(DelayDestroyGroupEnemys());
            StartCoroutine(DisbandedGroupEnemys());
        }


    }

    IEnumerator DisbandedGroupEnemys()
    {

        int _countElementEnemys = transform.childCount;
        for (int i = 0; i < _countElementEnemys; i++)
        {
            GameObject elemetEnemy = transform.GetChild(i).gameObject;
            elemetEnemy.GetComponent<PolygonCollider2D>().enabled = false;
            elemetEnemy.GetComponent<CapsuleCollider2D>().enabled = false;
            elemetEnemy.AddComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
        }

        yield return new WaitForSeconds(0.1f);


    }
    IEnumerator DelayDestroyGroupEnemys()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }


}
