using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineController : MonoBehaviour
{
    [SerializeField] private float _explosionValue;
    [SerializeField] private float _setExplosionTime;

    private float _currentExplosionTime;
    private Rigidbody _playerRigidbody;
    private bool _isDetectionPlayer;

    private void Awake()
    {
        Init();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("¿Ô´Ù");
            if (_playerRigidbody == null)
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

    private void Update()
    {
        CountTime(_isDetectionPlayer);
    }
    private void Init()
    {
        _currentExplosionTime = _setExplosionTime;
        _isDetectionPlayer = false;
    }

    private void CountTime(bool isActivate)
    {
        if (!isActivate)
        {
            return;
        }
        if(_playerRigidbody == null)
        {
            return;
        }
        _currentExplosionTime -= Time.deltaTime;
        if (_currentExplosionTime <= 0)
        {
            Explosion();
        }
    }
    private void Explosion()
    {
        _playerRigidbody.velocity = Vector3.up * _explosionValue;
        gameObject.SetActive(true);
    }
}
