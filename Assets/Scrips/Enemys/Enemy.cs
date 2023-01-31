using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int _levelEnemy = 1;
    int _numberLineEnemy = 0;
    EnemyManager myEnemyManager;
    bool _isDestroyEnemy = false;
    private void Awake()
    {
        myEnemyManager = FindObjectOfType<EnemyManager>();
    }
    void Start()
    {
        _numberLineEnemy = myEnemyManager.GetLineEnemy(_levelEnemy);
    }

    void LossOfLife()
    {
        _numberLineEnemy -= 1;
    }
    private void Update()
    {
        if (_numberLineEnemy == 0 && !_isDestroyEnemy)
        {
            _isDestroyEnemy = true;
            if (gameObject != null)
            {
                StartCoroutine(DelayDestroyEnemy());
            }
        }
    }
    IEnumerator DelayDestroyEnemy()
    {


            transform.SetParent(GameObject.Find("CreateEnemys").transform);
            GetComponent<PolygonCollider2D>().enabled = false;
            GetComponent<CapsuleCollider2D>().enabled = false;
            gameObject.AddComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
            yield return new WaitForSeconds(1f);
            Destroy(this.gameObject);



    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Bullet"))
        {
            LossOfLife();
            Destroy(other.gameObject);
        }
    }
}
