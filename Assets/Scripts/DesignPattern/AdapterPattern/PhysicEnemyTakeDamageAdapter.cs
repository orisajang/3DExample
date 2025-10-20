using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicEnemyTakeDamageAdapter : MonoBehaviour
{
    [SerializeField] private float _defense;
    private PhysicsEnemy _enemy;
    private void Start()
    {
        _enemy = GetComponent<PhysicsEnemy>();
        if (_enemy == null)
            gameObject.SetActive(false);
    }
    public void OnTakeDamage(float damage)
    {
        _enemy.OnTakePhysicsDamage(damage,2);
    }
}
