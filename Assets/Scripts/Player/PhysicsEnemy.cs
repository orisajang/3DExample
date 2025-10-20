using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsEnemy : Enemy
{
    [SerializeField] private float _defense;
    public void OnTakePhysicsDamage(float damage,float defense)
    {
        float resultDamage = (damage - defense) < 0 ? 0 : (damage - defense);
        Debug.Log($"PhysicsEnemyHp = {_curHp}");
        _curHp -= resultDamage;
        if (_curHp <= 0)
        {
            _curHp = 0;
            Destroy(gameObject);
        }
    }
}
