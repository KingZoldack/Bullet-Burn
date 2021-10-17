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

    void Start()
    {
        
    }

    void Update()
    {
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
        //transform.LookAt(_target);
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

    void LookAtPlayer()
    {
        var time = Time.time;
        Vector3 direction = (_target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        Quaternion.Slerp(lookRotation, transform.rotation, _rotationSpeed * time);
        time += Time.deltaTime;
    }

    void ChaseTarget()
    {
        //LookAtPlayer();

        //transform.LookAt(_target);
        _anim.SetBool(Tags.ENEMY_ATTACK_TAG, false);
        _anim.SetTrigger(Tags.ENEMY_MOVE_TAG);
        _navMeshAgent.SetDestination(_target.position);
    }

    void AttackTarget()
    {
        //LookAtPlayer();

        //transform.LookAt(_target);

        _anim.SetBool(Tags.ENEMY_ATTACK_TAG, true);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = _radiusColor;
        Gizmos.DrawWireSphere(transform.position, _chaseRange);
    }
}
