using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetControllerTest : MonoBehaviour
{
    //�÷��̾��� ��ġ�� �������ְ�, �ش� �÷��̾� ��ġ�� ���󰡴� ���� ������ּ���
    [SerializeField] float _moveSpeed;
    [SerializeField] float _distance;
    [SerializeField] PlayerControllerTest _player;
    Coroutine _coroutine;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _player._playerEvent.AddListener(SetCoroutine);
    }
    private void OnDestroy()
    {
        _player._playerEvent.RemoveListener(SetCoroutine);
    }

    private void SetCoroutine()
    {
        if(_coroutine == null)
        {
            _coroutine = StartCoroutine(EnemyMoveCoroutine(_player.transform));
        }
    }


    IEnumerator EnemyMoveCoroutine(Transform trf)
    {
        while(true)
        {
            float diff = Vector3.Distance(transform.position, trf.position);
            if(diff <= _distance)
            {
                _coroutine = null;
                yield break;
            }
            transform.position = Vector3.MoveTowards(transform.position, trf.position, Time.deltaTime * _moveSpeed);
            yield return null;
        }
    }

}
