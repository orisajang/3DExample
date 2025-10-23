using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMoveController : MonoBehaviour
{
    //구분용 레이어 변수 및 이동을 위한 변수들
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

    private void HandleMouseInput() //유저의 마우스 입력을 통해 레이캐스트를 사용하고 이동할 위치 정의
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

    private void MoveToTarget() //이동 기능
    {
        if(_hasTarget == false)
        {
            return;
        }
        Vector3 direction = _targetPos - transform.position; //이동 방향
        direction.y = 0f;
        float distance = direction.sqrMagnitude; //제곱근 형식으로 ( 0.05 * 0.05)

        if(distance > 0.05f) //아직 거리가 충분히 멀면
        {
            //회전
            Quaternion targetRot = Quaternion.LookRotation(direction.normalized); 
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, _rotateSpeed * Time.deltaTime); //Slerp란? 회전으로 하는 lerp라는데 몰라ㅋ
            //이동
            Vector3 move = direction.normalized * _moveSpeed * Time.deltaTime;
            if (move.sqrMagnitude > distance) move = direction.normalized * distance; //이거 왜해준거지?
            transform.position += move;
        }
        else
        {
            _hasTarget = false;
        }
    }

    private void OnDrawGizmos() //시각적 테스트용 기즈모함수, 구를 그려줌 (유니티 라이프사이클중에 OnDrawGizmos가 있음)
    {                           //테스트용 기능이라서 프로그램 빌드시 안보임 (근데 게임뷰에서는 보이는데 진짜인가? 흠.)
        if(_hasTarget)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(_targetPos + Vector3.up * 0.3f, 1);
        }
    }

}
