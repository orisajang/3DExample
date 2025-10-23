using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subject : MonoBehaviour
{
    //발행자 클래스 (구독자를 알고있어야함)

    //발행 대상이 될 구독자 리스트
    private List<IObserver> observers = new List<IObserver>(); 
    //구독, 해제 기능
    public void AddObserver(IObserver Observer) => observers.Add(Observer);
    public void RemoveObserver(IObserver Observer) => observers.Remove(Observer);
    private void Start()
    {
        Notify();
    }

    private void Notify()
    {
        foreach(IObserver Observer in observers)
        {
            Observer.OnNotify();
        }
    }
}
