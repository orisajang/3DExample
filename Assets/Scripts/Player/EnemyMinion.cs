using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMinion : Enemy
{
    [SerializeField][Range(0, 1)] float _weight;
     Vector3 leftEndPosZ;
    private void Update()
    {
        //z��ġ �������� ã�ƾ���
        //���1. �ٿ�� ��� (Singleton �� ���� ����� ����Ϸ����� �ʹ� �������.)
        //���2. ������ �˷��ִ� GameObject ����

        if (leftEndPosZ == null) return;
        //���2�� ���
        if (transform.position.z < leftEndPosZ.z)
        {
            Debug.Log($"z��ġ: {leftEndPosZ.z}");
            gameObject.SetActive(false);
        }
        transform.position += Vector3.back * (Time.deltaTime * _moveSpeed);
    }
    public void SetLeftEndPos(Transform leftEndPos)
    {
        leftEndPosZ = leftEndPos.position;
    }
}
