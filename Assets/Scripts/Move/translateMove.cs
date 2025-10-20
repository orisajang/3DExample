using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class translateMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    private void Awake()
    {
        Debug.Log("translateMove");
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);
    }
}
