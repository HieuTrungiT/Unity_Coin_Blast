using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortressManager : MonoBehaviour
{
    // State Bullet
    [Header("Speed Bullet")]
    [SerializeField] float _speedBullets;
    [SerializeField] float _speedAppearsPerSecond;
    [Header("Skills Bullet")]
    [SerializeField] bool _isExtraBarrelx2 = false;
    [SerializeField] bool _isExtraBarrelx3 = false;

    [SerializeField] bool _isShotSpeed = false;


    public float GetSpeedBullet()
    {
        return _speedBullets;
    }
    public float GetSpeedAppearsPerSecond()
    {
        return _speedAppearsPerSecond;
    }
    public bool GetIsExtraBarrelx2()
    {
        return _isExtraBarrelx2;
    }
    public bool GetIsExtraBarrelx3()
    {
        return _isExtraBarrelx3;
    }
    public bool GetIsShotSpeed()
    {
        return _isShotSpeed;
    }

}
