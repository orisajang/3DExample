using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerUi : MonoBehaviour    //Subject Ŭ����
{
    //1�ʰ� ���������� UI�� TMP Text�� ����, Interface�� OnTimeChange��� ���� �����
    //�������̽��� �����ϴ� Ŭ�������� 1�ʰ� ���������� �̺�Ʈ�� �߻���Ŵ
    //Observer(������)���� Awake������ �ش� �̺�Ʈ�� �߰��Ѵ�
    private List<ITimeChange> _timeChangeList = new List<ITimeChange>();    //�̺�Ʈ ���
    public void AddTimeChange(ITimeChange time) => _timeChangeList.Add(time); //�����ڵ��� �̺�Ʈ �߰��Ҷ� ����ϴ� �޼���
    public void RemoveTimeChange(ITimeChange time) => _timeChangeList.Remove(time); //�̺�Ʈ ���� �� �߰��ϴ� �޼���
    private float currentTime = 0f; //���� �ð�
    private int previousSecond = 0; //���� �ð� (��)
    private void Awake()
    {
        currentTime = 0f; //�ʱ� �ð� ����
    }
    private void Update() //1�ʸ��� �̺�Ʈ ������ ���ؼ� ���
    {
        currentTime += Time.deltaTime;
        
        int currentSecond = Mathf.FloorToInt(currentTime); //�Ҽ��� ���� ������ ���� ����
        if(currentSecond > previousSecond) //1�ʸ��� üũ
        {
            Debug.Log(currentSecond + "�� ���");
            previousSecond = currentSecond;
            SetTimerInvoke(); //1�ʰ� ���������� Observer�鿡�� �˷���
        }
        
    }

    private void SetTimerInvoke() //��� Observer�鿡�� ���� �־���
    {
        foreach(ITimeChange item in _timeChangeList)
        {
            int currentSecond = Mathf.FloorToInt(currentTime);
            item.PrintNowTime(currentSecond);
        }
    }
}
