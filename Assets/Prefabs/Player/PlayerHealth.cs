using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;

    [SerializeField] float _maxHealth = 100f;

    [SerializeField] float _currentHealth;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        _currentHealth = _maxHealth;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamagePlayer(float damage)
    {
        _currentHealth -= damage;

        if (_currentHealth < 1)
        {
            Debug.Log("You have died");
        }
    }
}
