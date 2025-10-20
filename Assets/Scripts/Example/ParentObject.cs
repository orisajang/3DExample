using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentObject : MonoBehaviour
{
    public GameObject Target;
    public Transform TargetTransform;

    private void Awake()
    {
        Init();
    }
    private void Start()
    {
        ChildrenAction();
    }

    private void Init() 
    {
        TargetTransform = Target.GetComponent<Transform>();
        TargetTransform.SetParent(transform);
        ChildState child = transform.GetChild(0).GetComponent<ChildState>(); //1번째 자식에서 ChildState를 찾음
        child?.PrintParent(); // ?(NULL 조건부 연산자)로 존재할경우만 실행
    }

    private void ChildrenAction()
    {
        ChildState[] ch = GetComponentsInChildren<ChildState>();

        for(int i=0; i< ch.Length; i++)
        {
            //부모에서 자식 설정
            ch[i].transform.SetParent(gameObject.transform);
            ch[i].name = $"Child Object - {i}";

            ch[i].PrintParent();
        }
    }
}
