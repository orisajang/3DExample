using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetControllerScript : MonoBehaviour
{
    [SerializeField] private PlayerEventScript _player;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _moveStopDistance;

    private Coroutine _moveCoroutine;
    private void Init()
    {
        _player.OnPetCalled.AddListener(MoveToPlayer);
    }
    private void Awake()
    {
        Init();
    }
    private void OnDestroy()
    {
        _player.OnPetCalled.RemoveListener(MoveToPlayer);
    }

    private void MoveToPlayer() //플레이어의 유니티 이벤트에 연결해줄 코루틴 실행 함수, 코루틴이 중복 실행되지 않도록 조건 추가함
    {
        if(_moveCoroutine == null)
        {
            _moveCoroutine = StartCoroutine(MoveToTarget(_player.transform));
        }
    }

    private IEnumerator MoveToTarget(Transform target) //플레이어를 따라서 이동하는데 정해진 간격까지 이동하면 멈추도록 하는 코루틴 함수
    {
        while(true)
        {
            float distance = Vector3.Distance(target.transform.position, transform.position);

            if(distance < _moveStopDistance)
            {
                _moveCoroutine = null;
                yield break; //코루틴 종료. 끝남
            }
            transform.position = Vector3.MoveTowards(
                transform.position,
                target.position,
                _moveSpeed * Time.deltaTime
                );
            yield return null;   //1프레임마다 while문 내용 실행시키기위해 사용. 없으면 바로 플레이어 위치로 이동
        }
    }

}
