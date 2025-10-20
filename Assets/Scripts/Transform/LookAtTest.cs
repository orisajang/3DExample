using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTest : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void Update()
    {
        RotateObj();
    }
    private void RotateObj()
    {
        transform.LookAt(_target.position);
    }
}
