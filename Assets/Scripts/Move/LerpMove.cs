using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpMove : MonoBehaviour
{
    [SerializeField] private Transform _targetTrf;
    [SerializeField][Range(0,1)] private float _interpolate;

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
            _interpolate);
    }
}
