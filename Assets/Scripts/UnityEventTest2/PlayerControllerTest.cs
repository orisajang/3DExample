using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControllerTest : MonoBehaviour
{
    //Pet이 Player를 따라다니게 하고싶습니다. 유니티 이벤트로요
    //이벤트로 하게하자 . player에서 pet의 이벤트를 담고, 키입력시 Invoke
    [field: SerializeField] public UnityEvent _playerEvent;
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            InvokePlayerEvent();
        }
    }
    private void InvokePlayerEvent()
    {
        _playerEvent?.Invoke();
    }

}
