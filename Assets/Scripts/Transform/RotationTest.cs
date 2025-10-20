using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTest : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;

    private void Update()
    {
        RotateObj();
    }

    private void RotateObj()
    {
        transform.rotation = Quaternion.Euler(
            transform.rotation.eulerAngles.x,
            transform.rotation.eulerAngles.y + _rotateSpeed * Time.deltaTime,
            transform.rotation.eulerAngles.z
            );
    }
}
