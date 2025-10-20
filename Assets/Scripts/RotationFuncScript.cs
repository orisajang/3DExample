using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationFuncScript : MonoBehaviour
{
    [SerializeField] float _Speed = 1;
    void Update()
    {
        RotateObj();
    }
    private void RotateObj()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * _Speed,Space.World);
    }
}
