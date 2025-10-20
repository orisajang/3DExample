using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float _moveSpeed = 1.0f;
    [SerializeField] protected float _damage;
    [SerializeField] protected float _maxHp;
    protected float _curHp;
    protected Rigidbody _rigidbody;
    bool isCollisionEnter = false;
    private void Awake()
    {
        InitEnemy();
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void InitEnemy()
    {
        _curHp = _maxHp;
    }
    private void Update()
    {
        //transform.position = Vector3.Lerp(transform.position, playerTransform.position, Time.deltaTime * _speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if (!isCollisionEnter) //collision Enter�� 2ȸ�̻� ȣ��Ǵ� ���� �߻�. 
            {
                isCollisionEnter = true;
                Player player = collision.gameObject.GetComponent<Player>();
                if (player == null) return;
                //Destroy(gameObject);
                gameObject.SetActive(false);
                player.OnTakeDamage(_damage);
                return;
            }
        }
        if(collision.gameObject.CompareTag("PlayerBullet"))
        {
            Debug.Log($"���� �浹 ���� :{collision.gameObject.name}�� �浹");
            //Destroy(gameObject);
            gameObject.SetActive(false); 
        }
    }
}
