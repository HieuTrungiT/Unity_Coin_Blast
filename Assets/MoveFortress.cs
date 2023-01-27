using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFortress : MonoBehaviour
{
    Vector2 initialPosition;
    Vector3 offset;
    void Start()
    {
        initialPosition = transform.position;
    }


    void Update()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void OnMouseUp()
    {
        // if (checkTriggerPointThrow < 1 && !isThrow)
        // {
        // transform.position = offset;
        // }
    }
    private void OnMouseDrag()
    {

            transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x + offset.x, -2.947f);



    }
}
