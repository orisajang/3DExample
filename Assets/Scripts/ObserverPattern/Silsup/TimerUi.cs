using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerUi : MonoBehaviour    //Subject 클래스
{
    //1초가 지날때마다 UI의 TMP Text가 변경, Interface는 OnTimeChange라는 것을 만들고
    //인터페이스를 관리하는 클래스에서 1초가 지난시점에 이벤트를 발생시킴
    //Observer(관찰자)들은 Awake시점에 해당 이벤트를 추가한다
    private List<ITimeChange> _timeChangeList = new List<ITimeChange>();    //이벤트 목록
    public void AddTimeChange(ITimeChange time) => _timeChangeList.Add(time); //관찰자들이 이벤트 추가할때 사용하는 메서드
    public void RemoveTimeChange(ITimeChange time) => _timeChangeList.Remove(time); //이벤트 삭제 시 추가하는 메서드
    private float currentTime = 0f; //현재 시간
    private int previousSecond = 0; //이전 시간 (초)
    private void Awake()
    {
        currentTime = 0f; //초기 시간 설정
    }
    private void Update() //1초마다 이벤트 보내기 위해서 사용
    {
        currentTime += Time.deltaTime;
        
        int currentSecond = Mathf.FloorToInt(currentTime); //소수점 이하 무조건 버린 숫자
        if(currentSecond > previousSecond) //1초마다 체크
        {
            Debug.Log(currentSecond + "초 경과");
            previousSecond = currentSecond;
            SetTimerInvoke(); //1초가 지날때마다 Observer들에게 알려줌
        }
        
    }

    private void SetTimerInvoke() //모든 Observer들에게 값을 넣어줌
    {
        foreach(ITimeChange item in _timeChangeList)
        {
            int currentSecond = Mathf.FloorToInt(currentTime);
            item.PrintNowTime(currentSecond);
        }
    }
}
