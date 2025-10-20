using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyScript : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float _force;
    [SerializeField] private float _velocityValue;

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
        if(Input.GetKeyDown(KeyCode.Q))
        {
            _rigidbody.AddForce(Vector3.up * _force, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            _rigidbody.velocity = Vector3.up * _velocityValue;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            _rigidbody.AddTorque(Vector3.up * _force);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _rigidbody.angularVelocity = Vector3.up * _velocityValue;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
        }
    }
}
