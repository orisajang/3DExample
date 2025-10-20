using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControllerTest : MonoBehaviour
{
    //Pet�� Player�� ����ٴϰ� �ϰ�ͽ��ϴ�. ����Ƽ �̺�Ʈ�ο�
    //�̺�Ʈ�� �ϰ����� . player���� pet�� �̺�Ʈ�� ���, Ű�Է½� Invoke
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
