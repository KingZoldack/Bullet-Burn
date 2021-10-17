using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] float _chaseRange = 5f;

    NavMeshAgent _navMeshAgent;

    float _distanceToTarget = Mathf.Infinity;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _navMeshAgent.SetDestination(_target.position);
    }
}
