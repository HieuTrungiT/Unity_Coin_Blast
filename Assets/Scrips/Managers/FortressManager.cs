using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortressManager : MonoBehaviour
{
    [SerializeField] float _speedBullets;
    [SerializeField] float _speedAppearsPerSecond;
    public float GetSpeedBullet()
    {
        return _speedBullets;
    }

    public float GetSpeedAppearsPerSecond()
    {
        return _speedAppearsPerSecond;
    }
}
