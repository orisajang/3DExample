using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardMove : MonoBehaviour
{
    [SerializeField] private Transform _targetTrf;
    [SerializeField] private float _moveSpeed;

    private void Update()
    {
        MoveObj();
    }

    private void MoveObj()
    {
        if (_targetTrf == null) return;
        transform.position = Vector3.Lerp(
            transform.position,
            _targetTrf.position,
            _moveSpeed * Time.deltaTime);
    }
}
