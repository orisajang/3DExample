using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UiTimeSet : MonoBehaviour, ITimeChange
{
    //UI�� �ð��� �ֱ�
    [SerializeField] TextMeshProUGUI guiText;  //TMP Text�� ǥ���ϱ� ���ؼ�
    [SerializeField] TimerUi timerUi;   //� ������󿡼� ���� �޾ƿð�����

    public void PrintNowTime(float fTime)
    {
        guiText.text = fTime.ToString(); //TMP Text �� ����
    }

    private void Awake()
    {
        timerUi.AddTimeChange(this); //����
    }
    private void OnDisable()
    {
        timerUi.RemoveTimeChange(this); //���� ����
    }
}
