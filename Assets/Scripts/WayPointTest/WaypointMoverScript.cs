using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMoverScript : MonoBehaviour
{
    [SerializeField] private float _moveSpeed; //�̵��ӵ�
    private int _currentTargetIndex = 0; //��������Ʈ ����� ��ġ�� ���ִ��� Ȯ��
    private Transform _wayPointBox;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("WaypointChecker"))
        {
            if (_wayPointBox == null) return;
            _currentTargetIndex += 1;

            if (_currentTargetIndex >= _wayPointBox.childCount)
                _currentTargetIndex = 0;
           // Debug.Log(_currentTargetIndex);
        }
    }
    private void Update()
    {
        MoveObj();
    }

    public void SetWayPointBox(Transform waypointBox) //��������Ʈ ����
    {
        _wayPointBox = waypointBox;
    }
    private void MoveObj() //�̵��Լ�
    {
        if (_wayPointBox == null) return;

        Transform targerTrf = _wayPointBox.GetChild(_currentTargetIndex);  //���� �������ϴ� ���� ����
        Vector3 direction = (targerTrf.position - transform.position).normalized; //�̵��ؾ��� ���� ���
        transform.position += direction * _moveSpeed * Time.deltaTime; //�̵�
    }
}
