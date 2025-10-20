using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundTest : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _rotateSpeed;

    private void Update()
    {
        RotateObj();
    }

    private void RotateObj()
    {
        transform.RotateAround(
            _target.position,
            Vector3.up,
            _rotateSpeed * Time.deltaTime
            );
    }
}
