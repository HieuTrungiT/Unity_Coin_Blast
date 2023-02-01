using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int _levelEnemy = 1;
    [SerializeField] GameObject _pfParticleEffectCollision;
    EnemyManager myEnemyManager;
    int _numberLineEnemy = 0;
    bool _isDestroyEnemy = false;
    Vector3 _initialPosition;

    private Vector3 originPosition;
    private float temp_shake_intensity = 0.03f;
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
        Debug.Log(_initialPosition);
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
    private void OnCollisionEnter2D(Collision2D other)
    {

        Instantiate(_pfParticleEffectCollision, transform.position, Quaternion.identity).GetComponent<ParticleSystem>().Play();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Bullet"))
        {
            LossOfLife();
            StartCoroutine(VibrateEnemy());
            Destroy(other.gameObject);
        }
    }
    IEnumerator VibrateEnemy()
    {
        _initialPosition = transform.position;

        for (int i = 0; i < 10; i++)
        {
            transform.position = transform.position + Random.insideUnitSphere * temp_shake_intensity;
            yield return new WaitForSeconds(0.01f);
        }
        // transform.position = _initialPosition;
    }

}
