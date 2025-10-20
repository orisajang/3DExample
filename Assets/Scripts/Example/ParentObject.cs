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
        ChildState child = transform.GetChild(0).GetComponent<ChildState>(); //1��° �ڽĿ��� ChildState�� ã��
        child?.PrintParent(); // ?(NULL ���Ǻ� ������)�� �����Ұ�츸 ����
    }

    private void ChildrenAction()
    {
        ChildState[] ch = GetComponentsInChildren<ChildState>();

        for(int i=0; i< ch.Length; i++)
        {
            //�θ𿡼� �ڽ� ����
            ch[i].transform.SetParent(gameObject.transform);
            ch[i].name = $"Child Object - {i}";

            ch[i].PrintParent();
        }
    }
}
