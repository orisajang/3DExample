using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    [SerializeField] private int _maxDeactiveCount;
    private int _currentDeactiveCount;
    private void Awake()
    {
        Init();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "PlayerBullet")
        {
            TakeDamage();
        }
    }
    private void Init()
    {
        _currentDeactiveCount = _maxDeactiveCount;
    }
    private void TakeDamage()
    {
        _currentDeactiveCount--;
        if(_currentDeactiveCount <=0)
        {
            gameObject.SetActive(false);
        }
    }
}
