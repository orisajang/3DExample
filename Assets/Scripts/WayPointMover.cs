using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed; //�ش� ������Ʈ�� �̵��� �ӵ�
    private int _currentTargetIndex = 0; //WayPoint�߿� ��� ���ִ°�
    private Transform _wayPointBox; //WayPoint�� ��Ƶ� Ʈ������ -> �ڽĵ��� ��������Ʈ�ϱ� ������� ��������Ʈ ����

    public void SetWayPointBox(Transform waypointBox) //�긦 ��ȯ���� �ܺ� Ŭ������ ȣ���� �� �ִ�, ��������Ʈ ���� �Լ�
    {
        _wayPointBox = waypointBox;
    }

    private void OnTriggerEnter(Collider other) //�浹 üũ�� ���� ��������Ʈ �̵�
    {
        //��������Ʈ�� �����Ѱ� �´��� Ȯ��
        if(other.CompareTag("WaypointChecker"))
        {
            if (_wayPointBox == null) 
                return;
            _currentTargetIndex += 1; //Ÿ���̵�
            if (_currentTargetIndex >= _wayPointBox.childCount) //�ڽ��� ������ �ε��� ���� �������� �ʵ��� ó��
                _currentTargetIndex = 0;
        }
    }
    private void Update()
    {
        MoveObj();
    }
    private void MoveObj() //���� ��������Ʈ�� �̵� �Լ�
    {
        if (_wayPointBox == null) //�̵� ������ ���� ���������ٸ� return
            return;

        Transform targetTrf = _wayPointBox.GetChild(_currentTargetIndex); //���� ������ �ϴ� ������ ������ ��������

        //�� ������ �������� �̵��ؾ��� ������ �������
        Vector3 direction = (targetTrf.position - transform.position).normalized; //�ٶ󺸴� ����
        transform.position += direction * _moveSpeed * Time.deltaTime; //���� �������� �̵�����
    }
}
