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

    private void MoveToPlayer() //�÷��̾��� ����Ƽ �̺�Ʈ�� �������� �ڷ�ƾ ���� �Լ�, �ڷ�ƾ�� �ߺ� ������� �ʵ��� ���� �߰���
    {
        if(_moveCoroutine == null)
        {
            _moveCoroutine = StartCoroutine(MoveToTarget(_player.transform));
        }
    }

    private IEnumerator MoveToTarget(Transform target) //�÷��̾ ���� �̵��ϴµ� ������ ���ݱ��� �̵��ϸ� ���ߵ��� �ϴ� �ڷ�ƾ �Լ�
    {
        while(true)
        {
            float distance = Vector3.Distance(target.transform.position, transform.position);

            if(distance < _moveStopDistance)
            {
                _moveCoroutine = null;
                yield break; //�ڷ�ƾ ����. ����
            }
            transform.position = Vector3.MoveTowards(
                transform.position,
                target.position,
                _moveSpeed * Time.deltaTime
                );
            yield return null;   //1�����Ӹ��� while�� ���� �����Ű������ ���. ������ �ٷ� �÷��̾� ��ġ�� �̵�
        }
    }

}
