using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CExampleForObserver : MonoBehaviour, IObserver
{
    [SerializeField] private Subject _subject;  //���� ���ϸ� ��ȯ���� �� �������
    private void Awake()
    {
        _subject?.AddObserver(this);
    }
    private void OnDestroy() //����. ���� ���ϸ� ��ȯ����.
    {
        _subject?.RemoveObserver(this);
    }

    public void OnNotify() //�������̽����� ����� �Լ�
    {
        Debug.Log($"�� �ް���� �ʾ�");
    }
}
