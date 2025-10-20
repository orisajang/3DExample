using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _moverPrefab; //��ȯ�� ��� ������
    [SerializeField] private Transform _waypointBox; //��ȯ ��󿡰� ������ ��������Ʈ ����
    [SerializeField] private float _spawnDelay; //��ȯ ����

    private WaitForSeconds _delay;
    private void Start()
    {
        _delay = new WaitForSeconds(_spawnDelay);
        StartCoroutine(SpawnMover());
    }

    private IEnumerator SpawnMover() //��ȯ�� ����� �ڷ�ƾ �Լ�
    {
        if (_waypointBox == null)
            yield break;

        while (true) 
        {
            GameObject newMoverObj = Instantiate(_moverPrefab, transform); //���ο� ��ü ����
            WayPointMover newMover = newMoverObj.GetComponent<WayPointMover>(); //������ ��ü���� �츮�� ���� ��������Ʈ �̵� ������Ʈ ���� ������
            newMover?.SetWayPointBox(_waypointBox); //�̵��� ��ġ�鿡 ���� ������ ����

            yield return _delay; //������ �ð� �������� �����ϵ��� ����
        }
    }
}
