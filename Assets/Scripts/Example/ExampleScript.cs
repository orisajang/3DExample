using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    int count = 0;
    int count2 = 0; int count3 = 0;
    private void Awake()
    {
        Debug.Log($"{MethodBase.GetCurrentMethod().Name} 호출"); //1
    }
    private void OnEnable()
    {
        Debug.Log($"{MethodBase.GetCurrentMethod().Name} 호출"); //2
    }
    private void Start()
    {
        Debug.Log($"{MethodBase.GetCurrentMethod().Name} 호출"); //3
    }
    
    private void Update()
    {
        if (count == 0)
        {
            count++;
            Debug.Log($"{MethodBase.GetCurrentMethod().Name} 호출"); //5
        }
        
    }
    private void FixedUpdate()
    {
        if (count2 == 0)
        {
            count2++;
            Debug.Log($"{MethodBase.GetCurrentMethod().Name} 호출"); //4
        }
        
    }
    private void LateUpdate()
    {
        if (count3 == 0)
        {
            count3++;
            Debug.Log($"{MethodBase.GetCurrentMethod().Name} 호출"); //6
        }
        
    }
    private void OnDisable()
    {
        Debug.Log($"{MethodBase.GetCurrentMethod().Name} 호출"); //7
    }
    private void OnDestroy()
    {
        Debug.Log($"{MethodBase.GetCurrentMethod().Name} 호출"); //8
    }
}
