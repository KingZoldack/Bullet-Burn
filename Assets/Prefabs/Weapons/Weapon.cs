﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Ammo _ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] Camera _FPCamera;
    [SerializeField] GameObject _hitEffect;
    [SerializeField] ParticleSystem _muzzleFlash;
    [SerializeField] float _bulletImapctLiftime = 0.1f;
    [SerializeField] float _range = 100f;
    [SerializeField] float _bulletDamage = 20f;
    [SerializeField] float _timeBetweenShots;

    bool _canShoot = true;

    private void OnEnable()
    {
        _canShoot = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        //Add SMG fire rate functionality.
        _canShoot = false;
        if (_ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            _ammoSlot.DecreaseCurrentAmmo(ammoType);
            ProcessMuzzleFlash();
            ProcessRaycast();
        }
        yield return new WaitForSeconds(_timeBetweenShots);
        _canShoot = true;
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
            target.TakeDamage(_bulletDamage);
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
