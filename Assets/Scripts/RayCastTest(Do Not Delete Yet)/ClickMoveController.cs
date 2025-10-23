using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMoveController : MonoBehaviour
{
    //���п� ���̾� ���� �� �̵��� ���� ������
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _rotateSpeed = 10f;

    private Vector3 _targetPos;
    private bool _hasTarget = false;

    private void Awake()
    {
        if (_playerCamera == null) _playerCamera = Camera.main;

        _targetPos = transform.position;
    }
    private void Update()
    {
        HandleMouseInput();
        MoveToTarget();
    }

    private void HandleMouseInput() //������ ���콺 �Է��� ���� ����ĳ��Ʈ�� ����ϰ� �̵��� ��ġ ����
    {
        if(Input.GetMouseButtonDown(1))
        {
            Ray ray = _playerCamera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hit, 100f,_groundMask))
            {
                _targetPos = hit.point;
                _hasTarget = true;
            }
        }
    }

    private void MoveToTarget() //�̵� ���
    {
        if(_hasTarget == false)
        {
            return;
        }
        Vector3 direction = _targetPos - transform.position; //�̵� ����
        direction.y = 0f;
        float distance = direction.sqrMagnitude; //������ �������� ( 0.05 * 0.05)

        if(distance > 0.05f) //���� �Ÿ��� ����� �ָ�
        {
            //ȸ��
            Quaternion targetRot = Quaternion.LookRotation(direction.normalized); 
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, _rotateSpeed * Time.deltaTime); //Slerp��? ȸ������ �ϴ� lerp��µ� ����
            //�̵�
            Vector3 move = direction.normalized * _moveSpeed * Time.deltaTime;
            if (move.sqrMagnitude > distance) move = direction.normalized * distance; //�̰� �����ذ���?
            transform.position += move;
        }
        else
        {
            _hasTarget = false;
        }
    }

    private void OnDrawGizmos() //�ð��� �׽�Ʈ�� ������Լ�, ���� �׷��� (����Ƽ ����������Ŭ�߿� OnDrawGizmos�� ����)
    {                           //�׽�Ʈ�� ����̶� ���α׷� ����� �Ⱥ��� (�ٵ� ���Ӻ信���� ���̴µ� ��¥�ΰ�? ��.)
        if(_hasTarget)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(_targetPos + Vector3.up * 0.3f, 1);
        }
    }

}
