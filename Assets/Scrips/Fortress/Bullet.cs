using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] GameObject _PfParticlEffectBullet;
    [SerializeField] GameObject _PfParticlEffectFeathers;
    FortressManager myFortressManager;

    private void Awake()
    {
        myFortressManager = FindObjectOfType<FortressManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("LimitPoint"))
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.tag.Equals("Enemy"))
        {
            GameObject _particalEffectBullet = Instantiate(_PfParticlEffectBullet, transform.position, Quaternion.identity);
            GameObject _particlEffectFeathers = Instantiate(_PfParticlEffectFeathers, transform.position, Quaternion.identity);
            _particalEffectBullet.GetComponent<ParticleSystem>().Play();
            _particlEffectFeathers.GetComponent<ParticleSystem>().Play();
            Destroy(gameObject);

        }
        else if (other.gameObject.tag.Equals("Shield"))
        {
            GameObject _particalEffectBullet = Instantiate(_PfParticlEffectBullet, transform.position, Quaternion.identity);
            _particalEffectBullet.GetComponent<ParticleSystem>().Play();
            other.gameObject.GetComponent<Shield>().SetLineShield();
            Destroy(gameObject);
        }
        else if (other.gameObject.tag.Equals("Boss"))
        {
            GameObject _particalEffectBullet = Instantiate(_PfParticlEffectBullet, transform.position, Quaternion.identity);
            GameObject _particlEffectFeathers = Instantiate(_PfParticlEffectFeathers, transform.position, Quaternion.identity);
            _particalEffectBullet.GetComponent<ParticleSystem>().Play();
            _particlEffectFeathers.GetComponent<ParticleSystem>().Play();
            other.gameObject.GetComponent<BossEnemy>().SetLineBoss();

            Destroy(gameObject);
        }
    }

    void MoveBullet()
    {
        transform.Translate(0, myFortressManager.GetSpeedBullet(), 0f);

    }
    private void FixedUpdate()
    {
        MoveBullet();

    }
}
