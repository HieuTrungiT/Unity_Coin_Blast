using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFortress : MonoBehaviour
{
    Vector2 initialPosition;
    Vector3 offset;
    Vector2 minBounds;
    Vector2 maxBounds;
    void Start()
    {
        initialPosition = transform.position;
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }


    void Update()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition).x);

    }

    private void OnMouseUp()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + 0.137f);
    }
    private void OnMouseDrag()
    {
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x >= minBounds.x + 0.5f || Camera.main.ScreenToWorldPoint(Input.mousePosition).x <= maxBounds.x -0.5f)
        {
            transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x + offset.x, -3.7f);
        }

    }
}

