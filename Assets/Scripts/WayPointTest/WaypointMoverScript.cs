using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMoverScript : MonoBehaviour
{
    [SerializeField] private float _moveSpeed; //이동속도
    private int _currentTargetIndex = 0; //웨이포인트 몇번쨰 위치에 와있는지 확인
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

    public void SetWayPointBox(Transform waypointBox) //웨이포인트 설정
    {
        _wayPointBox = waypointBox;
    }
    private void MoveObj() //이동함수
    {
        if (_wayPointBox == null) return;

        Transform targerTrf = _wayPointBox.GetChild(_currentTargetIndex);  //현재 가려고하는 지점 정보
        Vector3 direction = (targerTrf.position - transform.position).normalized; //이동해야할 방향 계산
        transform.position += direction * _moveSpeed * Time.deltaTime; //이동
    }
}
