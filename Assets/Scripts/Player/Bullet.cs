using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10.0f;
    [SerializeField] public static event Action<Bullet> OnBulletHit;

    private void Update()
    {
        transform.position += Vector3.forward * Time.deltaTime * _moveSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            /*
            //PhysicsEnemy physicsEnemy = other.GetComponent<PhysicsEnemy>();
            //physicsEnemy.OnTakeDamage(); //�̷��Ŵ�� ���
            ITakeDamageAdapter adapter = other.GetComponent<ITakeDamageAdapter>();
            if (adapter == null) return;
            adapter.OnTakeDamage(1);
            */
            OnBulletHit?.Invoke(this);
        }

        if(other.gameObject.CompareTag("Wall"))
        {
            Debug.Log($"�Ѿ��� � ��ü�� ���� !:{other.gameObject.name}�� �浹");
            Destroy(gameObject);
        }
        
    }

}