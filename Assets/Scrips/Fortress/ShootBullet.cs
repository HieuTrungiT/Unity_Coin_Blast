using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    [SerializeField] GameObject _Bullet;
    FortressManager myFortressManager;
    bool _isExtraBarrelx2 = false;
    bool _isExtraBarrelx3 = false;

    bool _isShotSpeed = false;



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
            yield return new WaitForSeconds(myFortressManager.GetSpeedAppearsPerSecond());

            // -------------------- Skills Bullet --------------------
            // Extra Barrel shot
            if (myFortressManager.GetIsExtraBarrelx2())
            {
                Instantiate(_Bullet, new Vector2(transform.position.x - 0.1f, transform.position.y), Quaternion.identity);
                Instantiate(_Bullet, new Vector2(transform.position.x + 0.1f, transform.position.y), Quaternion.identity);
            }
            else if (myFortressManager.GetIsExtraBarrelx3())
            {
                Instantiate(_Bullet, new Vector2(transform.position.x - 0.2f, transform.position.y), Quaternion.identity);
                Instantiate(_Bullet, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                Instantiate(_Bullet, new Vector2(transform.position.x + 0.2f, transform.position.y), Quaternion.identity);
            }
            else
            {
                Instantiate(_Bullet, transform.position, Quaternion.identity);
            }

            // Double shot
            if (myFortressManager.GetIsShotSpeed() && !myFortressManager.GetIsExtraBarrelx2() && !myFortressManager.GetIsExtraBarrelx3())
            {
                yield return new WaitForSeconds(0.05f);
                Instantiate(_Bullet, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            }
            else if (myFortressManager.GetIsShotSpeed() && myFortressManager.GetIsExtraBarrelx2())
            {
                yield return new WaitForSeconds(0.05f);
                Instantiate(_Bullet, new Vector2(transform.position.x - 0.1f, transform.position.y), Quaternion.identity);
                Instantiate(_Bullet, new Vector2(transform.position.x + 0.1f, transform.position.y), Quaternion.identity);
            }
            else if (myFortressManager.GetIsShotSpeed() && myFortressManager.GetIsExtraBarrelx3())
            {
                yield return new WaitForSeconds(0.1f);
                Instantiate(_Bullet, new Vector2(transform.position.x - 0.2f, transform.position.y), Quaternion.identity);
                Instantiate(_Bullet, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
                Instantiate(_Bullet, new Vector2(transform.position.x + 0.2f, transform.position.y), Quaternion.identity);
            }

            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);

        }
    }
}
