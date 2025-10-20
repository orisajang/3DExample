using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallControllerScript : MonoBehaviour
{
    [SerializeField] private float _deactivateTime;
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
        TimeCount();
    }
    private void Init()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void TimeCount()
    {
        _deactCount -= Time.deltaTime;
        if(_deactCount<= 0)
        {
            gameObject.SetActive(false);
        }
    }
    private void ActivateAction()
    {
        _rigidbody.velocity = Vector3.zero;
        _deactCount = _deactivateTime;
        _rigidbody.AddForce(transform.forward * _shotForce, ForceMode.Impulse);
    }

}
