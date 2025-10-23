using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMoveScript : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _detectSightDistance;

    private Ray _ray;
    private Rigidbody _rigidbody;
    public bool IsSelect;

    private void Awake()
    {
        Init();
    }
    private void Update()
    {
        if(IsSelect)
        {
            SetMove();
            DetectObjectInFront();
        }
    }
    private void OnDrawGizmos() //기즈모로 _ray 선 표시
    {
        if(IsSelect)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(_ray.origin, _ray.direction * _detectSightDistance);
        }
    }
    private void Init()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void SetMove()
    {
        Vector3 direction = GetDirectionFromInput();
        if(direction == Vector3.zero)
        {
            _rigidbody.velocity = Vector3.zero;
            return;
        }
        _rigidbody.transform.rotation = Quaternion.Lerp(
            transform.rotation, 
            Quaternion.LookRotation(direction), 
            _rotateSpeed * Time.deltaTime);
        _rigidbody.velocity = _moveSpeed * direction;
    }
    private Vector3 GetDirectionFromInput()
    {
        Vector3 dir = Vector3.zero;
        dir.x = Input.GetAxisRaw("Horizontal");
        dir.z = Input.GetAxisRaw("Vertical");
        return dir.normalized;
    }
    private void DetectObjectInFront() //Ray를 쏴서 확인함
    {
        _ray = new Ray(transform.position, transform.forward * _detectSightDistance);
        RaycastHit hit;
        if(Physics.Raycast(_ray,out hit, _detectSightDistance))
        {
            Debug.Log($"{name} : {hit.transform.name} 발견!");
        }
    }
}
