using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("LimitPoint"))
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.tag.Equals("Enemy"))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Enemy"))
        {
            Destroy(gameObject);
        }
    }


}
