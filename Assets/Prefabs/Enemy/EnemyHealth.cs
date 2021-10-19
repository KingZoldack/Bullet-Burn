using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public static EnemyHealth instance;

    [SerializeField] float _maxHealth = 100f;

    Animator _anim;

    float _currentHealth;
    float _enemyDespawnDelay = 3f;
    bool isDead;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        _anim = GetComponent<Animator>();

        _currentHealth = _maxHealth;
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(float Damage)
    {
        BroadcastMessage("OnDamaged");

        _currentHealth -= Damage;

        if (_currentHealth < 1f)
        {
            EnemyDie();
        }
    }

    private void EnemyDie()
    {
        if (isDead) return;
        isDead = true;
        _anim.SetBool(Tags.ENEMY_DEAD_TAG, true);
        Destroy(this.gameObject, _enemyDespawnDelay);
    }
}
