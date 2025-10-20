using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoverSpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject _moverPrefab; //��ȯ�� ��� ������
    [SerializeField] private Transform _waypointBox; //��������Ʈ ���� (��ȯ��󿡰� ����)
    [SerializeField] private float _spawnDelay; //��ȯ ����

    private void Start()
    {
        StartCoroutine(SpawnMover());
    }
    private IEnumerator SpawnMover() //��ȯ �ڷ�ƾ �Լ�
    {
        if (_waypointBox == null) yield break;

        while(true) //��� ��ȯ
        {
            GameObject newMoverObj = Instantiate(_moverPrefab, transform); //�� ��ü ����
            WaypointMoverScript newMover = newMoverObj.GetComponent<WaypointMoverScript>(); //��ü���� ������Ʈ ������
            newMover?.SetWayPointBox(_waypointBox); //�̵��� ��ġ ����
            yield return new WaitForSeconds(_spawnDelay);
        }
    }
}
