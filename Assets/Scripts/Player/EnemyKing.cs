using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKing : Enemy
{
    [SerializeField] private Transform playerTransform;
    void Update()
    {
        //����1. Lerp�� �ϴϱ� Player�� �浹�Ҷ� OnColliderEnter �̺�Ʈ�� 2�� �߻���
        //����: Unity ���� ������ �� FixedUpdate���� Collider �� �浹�� ���� �����ϱ� ����, ���� ������ �����Ӹ��� Collider�� ���� ���¸� ����� ��, ���� ���� ��ġ ��ȭ�� ���� �и����������� ���� �浹���� �Ǵ��ϱ� ����
        //�ذ���: OnColliderEnter�� �߻��� ��� �������� ������ bool���� true�� ���� 1���� üũ�ǵ��� ����
        transform.position = Vector3.Lerp(transform.position, playerTransform.position, Time.deltaTime * _moveSpeed);
    }
}
