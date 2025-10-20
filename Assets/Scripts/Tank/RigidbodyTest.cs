using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyTest : MonoBehaviour
{
    [SerializeField] private float _velocityValue = 5.0f;
    [SerializeField] private float _force = 5.0f;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            //_rigidbody.AddForce(Vector3.up * _force, ForceMode.Impulse);
            //_rigidbody.AddTorque(Vector3.up * _force);
            //_rigidbody.velocity = Vector3.up * _velocityValue;
            _rigidbody.angularVelocity = Vector3.up * _velocityValue;
        }
        if(Input.GetKeyDown(KeyCode.Z)) //∏ÿ√ﬂ±‚
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
        }
    }
}
