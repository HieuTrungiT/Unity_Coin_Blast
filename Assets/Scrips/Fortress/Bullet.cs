using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

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
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.Translate(0, myFortressManager.GetSpeedBullet(), 0f);
    }
}
