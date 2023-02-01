using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLightEffect : MonoBehaviour
{
    Vector2 minBounds;
    Vector2 maxBounds;
    private void Awake()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));

    }
    private void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - 0.004f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Ground"))
        {

            transform.position = new Vector2(Random.Range(minBounds.x, maxBounds.x), maxBounds.y);
            float _randomScale = Random.Range(0.3f, 0.1f);
            transform.localScale = new Vector2(_randomScale, _randomScale);
        }
    }

}
