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

    float _distanceToTarget = Mathf.Infinity;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        _distanceToTarget = Vector3.Distance(_target.position, transform.position);

        if (_distanceToTarget <= _chaseRange)
        {
            _navMeshAgent.SetDestination(_target.position);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = _radiusColor;
        Gizmos.DrawWireSphere(transform.position, _chaseRange);
    }
}
