using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    [SerializeField] int _Speed = 1;

    // Update is called once per frame
    void Update()
    {
        RotateObj();
    }
    private void RotateObj()
    {
        Quaternion quaternion = Quaternion.Euler(Vector3.forward * Time.deltaTime * _Speed); //����������� ȸ�������� ���� ������ ��Ȯ��
        transform.rotation = transform.rotation * quaternion; //���Ŀ� ȸ���߱⶧���� ȸ���� �ȴ�

        //transform.rotation = Quaternion.Euler(transform.rotation * Vector3.forward * Time.deltaTime * _Speed); //ȸ������. ����? .Euler���� ȸ�� ���� �ſ� ���� ������ ��ȯ�Ǳ⶧���� ȸ���� ���� ������ �ſ� �������� ��ȯ��
    }
}
