using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotation : MonoBehaviour
{
    [SerializeField] bool _isRotation = true;
    [SerializeField] bool _isDirectionLeft = true;
    [SerializeField] float _speedRotation = 1f;
    private void FixedUpdate()
    {
        if (_isRotation)
        {
            if (_isDirectionLeft)
            {
                transform.Rotate(0f, 0f, _speedRotation);
            }
            else
            {
                transform.Rotate(0f, 0f, -_speedRotation);

            }
        }
        else
        {
            transform.Rotate(0f, 0f, 0f);
        }
    }
}
