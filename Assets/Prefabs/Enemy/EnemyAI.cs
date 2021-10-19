using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] float _chaseRange = 5f;
    [SerializeField] Color _radiusColor;

    NavMeshAgent _navMeshAgent;
    Animator _anim;

    float _distanceToTarget = Mathf.Infinity;
    bool _isProvoked;
    float _rotationSpeed= 5f;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (EnemyHealth.instance.IsDead())
        {
            enabled = false;
            _navMeshAgent.enabled = false;
        }

        _distanceToTarget = Vector3.Distance(_target.position, transform.position);

        if (_isProvoked)
        {
            EngageTarget();
        }

        else if (_distanceToTarget <= _chaseRange)
        {
            _isProvoked = true;
        }

    }

    void EngageTarget()
    {
        LookAtPlayer();

        if (_distanceToTarget >= _navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }

        else if (_distanceToTarget <= _navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    public void OnDamaged()
    {
        _isProvoked = true;
    }

    void LookAtPlayer()
    {
        
        Vector3 direction = (_target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(lookRotation, transform.rotation, _rotationSpeed * Time.deltaTime);
    }

    void ChaseTarget()
    {
        _anim.SetBool(Tags.ENEMY_ATTACK_TAG, false);
        _anim.SetTrigger(Tags.ENEMY_MOVE_TAG);
        _navMeshAgent.SetDestination(_target.position);
    }

    void AttackTarget()
    {
        _anim.SetBool(Tags.ENEMY_ATTACK_TAG, true);
        GetComponent<EnemyAttack>().AttackHitEvent();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = _radiusColor;
        Gizmos.DrawWireSphere(transform.position, _chaseRange);
    }
}
