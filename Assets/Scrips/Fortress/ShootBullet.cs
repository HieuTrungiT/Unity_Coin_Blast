using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    [SerializeField] GameObject _Bullet;
    FortressManager myFortressManager;
    private void Awake()
    {
        myFortressManager = FindObjectOfType<FortressManager>();
    }
    void Start()
    {
        StartCoroutine(Shoot());
    }
    IEnumerator Shoot()
    {
        while (true)
        {
            transform.localScale = new Vector3(1.7f, 1.7f, 1.7f);
            yield return new WaitForSeconds(myFortressManager.GetSpeedAppearsPerSecond() );
            Instantiate(_Bullet, transform.position, Quaternion.identity);
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);

        }
    }
}
