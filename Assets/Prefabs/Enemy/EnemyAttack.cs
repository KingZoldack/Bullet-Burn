using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
     PlayerHealth _target;
    [SerializeField] float _damage = 40f;

    // Start is called before the first frame update
    void Start()
    {
        _target = PlayerHealth.instance;
    }

    public void AttackHitEvent()
    {
        if (_target == null) return;
        Debug.Log("The player was damaged");
        _target.DamagePlayer(_damage);
    }
}
