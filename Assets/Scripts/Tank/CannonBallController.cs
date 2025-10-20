using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallController : MonoBehaviour
{
    [SerializeField] private float _deactiveTime;
    [SerializeField] private float _shotForce;

    private Rigidbody _rigidbody;
    private float _deactCount;
    private void Awake()
    {
        Init();
    }
    private void OnEnable()
    {
        ActivateAction();
    }
    private void Update()
    {
        CountTime();
    }
    private void Init()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void CountTime()
    {
        _deactCount -= Time.deltaTime;
        if(_deactCount <= 0)
        {
            _rigidbody.velocity = Vector3.zero;
            gameObject.SetActive(false);
        }
    }
    private void ActivateAction()
    {
        _deactCount = _deactiveTime;
        _rigidbody.AddForce(transform.forward * _shotForce, ForceMode.Impulse);
    }
}
