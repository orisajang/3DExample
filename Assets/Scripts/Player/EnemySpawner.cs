using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject targetPrefab;
    [SerializeField] float _spawnTime;
    [SerializeField] int poolLength = 3;
    [SerializeField] Transform leftPosX;
    [SerializeField] Transform rightPosX;
    [SerializeField] Transform leftEndPosZ;

    private void Awake()
    {
        // + Spanw�� ������ġ���� ��������
        // + ������Ʈ Ǯ��
        // + �ڷ�ƾ �� Invoke �ΰ������ �����ϵ���
    }
    private void Update()
    {
        //RemoteCoroutine(); //�ڷ�ƾ ����
        GameManagerScript.Instance.RemoteCoroutine(leftPosX, rightPosX, leftEndPosZ);
    }

}
