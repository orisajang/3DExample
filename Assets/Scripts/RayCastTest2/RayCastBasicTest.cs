using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastBasicTest : MonoBehaviour
{
    private RaycastHit[] _hitBuffer = new RaycastHit[10];
    [SerializeField] private float _distance = 10f;
    [SerializeField] private float _moveSpeed = 3f;
    private void Update()
    {
        MoveMethod(); //�÷��̾� �̵� �Լ�
        RayCastFirst(); //�̰� ���� 1���� �����´�
       // RayCastAllTest(); // �� �Լ� �ּ� Ǯ�� Raycast ������ �����ü�����
    }

    private void MoveMethod()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(x, 0, z).normalized;
        transform.position += direction * (Time.deltaTime * _moveSpeed);
    }

    private void RayCastFirst() //�Ϲ� ����ĳ��Ʈ (ó�� 1���� ��ȯ)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _distance))
        {
            Debug.Log("�տ� ��ü���ִ�! �̸�:" + hit.collider.name);
            Debug.Log("�Ÿ�: " + hit.distance);
            Debug.Log("point:" + hit.point); //�浹���� ������ǥ
            Debug.Log("gameObject.transform.position:" + hit.collider.gameObject.transform.position); //�Ʒ��� ����
            Debug.Log("transform.position:" + hit.transform.position); //���� �������, ������ ��ü ��ġ

            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red, 1f);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * _distance, Color.green, 1f);
        }
    }
    private void RayCastAllTest()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if(Input.GetKeyDown(KeyCode.Z))
        {
            RaycastHit[] hits = Physics.RaycastAll(ray, _distance); //ray���̿��� 100f��ŭ �ִ� ������Ʈ���� ��� ����
            Debug.Log($"[RaycastAll]�浹 ����:{hits.Length}");
            foreach(RaycastHit hit in hits)
            {
                Debug.Log($"Hits:{hit.collider.name}, Distance:{hit.distance}");
            }
        }

        if(Input.GetKeyDown(KeyCode.X)) //������ _hitBuffer�� 10���̹Ƿ� 10���� ��������
        {
            int hitCount = Physics.RaycastNonAlloc(ray, _hitBuffer, _distance);
            Debug.Log($"[RaycastNonAlloc]�浹����: {hitCount}");
            for(int i=0; i<hitCount; i++)
            {
                Debug.Log($"Hits:{_hitBuffer[i].collider.name}, Distance:{_hitBuffer[i].distance}");
            }
        }

    }

}
