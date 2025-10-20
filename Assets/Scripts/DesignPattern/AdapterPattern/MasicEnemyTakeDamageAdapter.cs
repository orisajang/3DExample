using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasicEnemyTakeDamageAdapter : MonoBehaviour, ITakeDamageAdapter
{
    [SerializeField] private float _weakness;
    private MasicEnemy _enemy;  //어뎁티

    private void Start()    //동적연결
    {
        _enemy = GetComponent<MasicEnemy>();
        if (_enemy == null)
            gameObject.SetActive(false);
    }
    public void OnTakeDamage(float damage)
    {
        _enemy?.OnTakeMagicDamage(damage, _weakness);
    }
}
