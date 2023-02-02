using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    EnemyManager myEnemyManager;
    CreateEnemys myCreateEnemtys;
    int lineShield = 0;
    private void Awake()
    {
        myCreateEnemtys = FindObjectOfType<CreateEnemys>();
        myEnemyManager = FindObjectOfType<EnemyManager>();
        lineShield = myEnemyManager.GetLineShield();
    }
    private void Update()
    {
        Debug.Log(myCreateEnemtys.GetCountEnemys());
        if (lineShield == 0)
        {
            lineShield -= 1;
            Debug.Log("mất khiên");
            GetComponent<CircleCollider2D>().enabled = false;
            gameObject.AddComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
            StartCoroutine(DelayDestroyShield());
        }
    }
    IEnumerator DelayDestroyShield()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
    public void SetLineShield()
    {
        lineShield -= 1;
    }

}
