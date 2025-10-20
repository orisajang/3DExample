using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKing : Enemy
{
    [SerializeField] private Transform playerTransform;
    void Update()
    {
        //문제1. Lerp로 하니까 Player랑 충돌할때 OnColliderEnter 이벤트가 2번 발생함
        //이유: Unity 물리 엔진이 매 FixedUpdate마다 Collider 간 충돌을 새로 감지하기 때문, 물리 엔진이 프레임마다 Collider의 접촉 상태를 계산할 때, 아주 작은 위치 변화나 접촉 분리·재접촉을 “새 충돌”로 판단하기 때문
        //해결방법: OnColliderEnter이 발생할 경우 전역으로 설정한 bool값을 true로 만들어서 1번만 체크되도록 설정
        transform.position = Vector3.Lerp(transform.position, playerTransform.position, Time.deltaTime * _moveSpeed);
    }
}
