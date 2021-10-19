using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public static EnemyHealth instance;

    [SerializeField] float _maxHealth = 100f;

    float _currentHealth;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float Damage)
    {
        BroadcastMessage("OnDamaged");

        _currentHealth -= Damage;

        if (_currentHealth < 1f)
        {
            Destroy(this.gameObject);
        }
    }
}
