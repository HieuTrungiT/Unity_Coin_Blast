using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticleEfffect : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(DestroyParticleEffect());
    }
    IEnumerator DestroyParticleEffect()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
