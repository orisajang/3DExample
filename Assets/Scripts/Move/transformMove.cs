using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transformMove : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    private void Awake()
    {
        Debug.Log("transformMove");
    }
    private void Update()
    {
        transform.position += Vector3.forward * _moveSpeed * Time.deltaTime;
    }
}
