using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineControllerScript : MonoBehaviour
{
    //Mine�� �΋H���� ������Ʈ�� Player �±׸� �������־����
    [SerializeField] private float _explosionValue;
    [SerializeField] private float _setExplosionTime;
    private float _currentExplosionTime;
    private Rigidbody _playerRigidbody;
    private bool _isDetectionPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(_playerRigidbody == null)
            {
                _playerRigidbody = other.GetComponent<Rigidbody>();
            }
            _isDetectionPlayer = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            Init();
        }
    }
    private void Awake()
    {
        Init();
    }
    private void Update()
    {
        TimeCount(_isDetectionPlayer);
    }

    private void Init()
    {
        _currentExplosionTime = _setExplosionTime;
        _isDetectionPlayer = false;
    }

    private void TimeCount(bool isActivate)
    {
        if (!isActivate) return;
        if (_playerRigidbody == null) return;
        Debug.Log(_currentExplosionTime);
        _currentExplosionTime -= Time.deltaTime;
        if(_currentExplosionTime <=0)
        {
            Explosion();
        }
    }

    private void Explosion()
    {
        _playerRigidbody.velocity = GetRanddirection() * _explosionValue;
        gameObject.SetActive(false);
        Debug.Log("����");
    }
    private Vector3 GetRanddirection() //������ �������� �÷��̾ ���ư����� �ϱ����ؼ� ���
    {
        return new Vector3(
            Random.Range(-1f, 1f),
            1,
            Random.Range(-1f, 1f));
    }

}
