using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UiTimeSet : MonoBehaviour, ITimeChange
{
    //UI에 시간을 넣기
    [SerializeField] TextMeshProUGUI guiText;  //TMP Text에 표시하기 위해서
    [SerializeField] TimerUi timerUi;   //어떤 관찰대상에서 값을 받아올것인지

    public void PrintNowTime(float fTime)
    {
        guiText.text = fTime.ToString(); //TMP Text 값 수정
    }

    private void Awake()
    {
        timerUi.AddTimeChange(this); //구독
    }
    private void OnDisable()
    {
        timerUi.RemoveTimeChange(this); //구독 해제
    }
}
