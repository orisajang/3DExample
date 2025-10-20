using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasicEnemy : Enemy
{
    // Start is called before the first frame update
    public void OnTakeMagicDamage(float damage, float weakness)
    {
        float resultDamage = damage * weakness;
        _curHp -= resultDamage;
        Debug.Log($"MasicEnemyHp = {_curHp}");
        if (_curHp <= 0)
        {
            _curHp = 0;
            Destroy(gameObject);
        }
    }
}
