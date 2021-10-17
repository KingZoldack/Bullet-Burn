using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera _FPCamera;
    [SerializeField] float _range = 100f;
    [SerializeField] float _clipperBulletDamage = 20f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(_FPCamera.transform.position, _FPCamera.transform.forward, out hit, _range))
        {
            Debug.Log($"{hit.transform.name} was shot at.");
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(_clipperBulletDamage);
        }

        else
        {
            return;
        }
    }
}
