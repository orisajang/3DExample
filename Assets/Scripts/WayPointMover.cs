using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed; //해당 오브젝트가 이동할 속도
    private int _currentTargetIndex = 0; //WayPoint중에 어디에 와있는가
    private Transform _wayPointBox; //WayPoint를 담아둔 트랜스폼 -> 자식들이 웨이포인트니까 얘들통해 웨이포인트 접근

    public void SetWayPointBox(Transform waypointBox) //얘를 소환해줄 외부 클래스가 호출할 수 있는, 웨이포인트 설정 함수
    {
        _wayPointBox = waypointBox;
    }

    private void OnTriggerEnter(Collider other) //충돌 체크를 통한 웨이포인트 이동
    {
        //웨이포인트에 접근한게 맞는지 확인
        if(other.CompareTag("WaypointChecker"))
        {
            if (_wayPointBox == null) 
                return;
            _currentTargetIndex += 1; //타겟이동
            if (_currentTargetIndex >= _wayPointBox.childCount) //자식의 수보다 인덱스 값이 높아지지 않도록 처리
                _currentTargetIndex = 0;
        }
    }
    private void Update()
    {
        MoveObj();
    }
    private void MoveObj() //다음 웨이포인트로 이동 함수
    {
        if (_wayPointBox == null) //이동 지점에 대한 정보가없다면 return
            return;

        Transform targetTrf = _wayPointBox.GetChild(_currentTargetIndex); //현재 가고자 하는 지점의 정보를 가져오자

        //이 정보를 바탕으로 이동해야할 방향을 계산하자
        Vector3 direction = (targetTrf.position - transform.position).normalized; //바라보는 방향
        transform.position += direction * _moveSpeed * Time.deltaTime; //계산된 방향으로 이동하자
    }
}
