using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera _FPCamera;
    [SerializeField] GameObject _hitEffect;
    [SerializeField] ParticleSystem _muzzleFlash;
    [SerializeField] float _bulletImapctLiftime = 0.1f;
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
        ProcessMuzzleFlash();
        ProcessRaycast();
    }

    private void ProcessMuzzleFlash()
    {
        _muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(_FPCamera.transform.position, _FPCamera.transform.forward, out hit, _range))
        {
            DamageEnemy(hit);
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

    void DamageEnemy(RaycastHit hit)
    {
        var impact = Instantiate(_hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, _bulletImapctLiftime);
    }
}
