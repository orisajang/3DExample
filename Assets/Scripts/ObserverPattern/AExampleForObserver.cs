using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AExampleForObserver : MonoBehaviour, IObserver
{
    [SerializeField] private Subject _subject;  //해제 안하면 순환참조 꼭 해줘야함
    private void Awake()
    {
        _subject?.AddObserver(this);
    }
    private void OnDestroy() //주의. 해제 안하면 순환참조.
    {
        _subject?.RemoveObserver(this);
    }

    public void OnNotify() //인터페이스에서 약속한 함수
    {
        Debug.Log($"{gameObject.name} Received");
    }
}
