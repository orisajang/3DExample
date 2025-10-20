using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    //Instance ������Ƽ�� Awake���� �Ѵ� nullüũ�� �ϴ� ����:
    //�ܺο��� Instance�� ȣ���ϴ°�� �����ǰ�
    //�̹� ������ �����Ǿ�������� ������Ƽ�� ȣ������¾ʰ� Awake���� ���� ȣ��ǹǷ�

    //�ܺ� ȣ��� ������Ƽ, �ش� Ÿ���� �̱����� ������ ã�ƺ��� �׷��� ������ ���� ���� �� ����
    public static T Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<T>(); //ã�ƺ�
                
                if(_instance == null)
                {
                    GameObject singletonObj = new GameObject();
                    _instance = singletonObj.AddComponent<T>();
                    singletonObj.name = typeof(T).ToString();
                }
            }
            return _instance;
        }
    }
    protected virtual void Awake() //�ߺ�üũ �� ������ ���� (������ ����)
    {
        if(_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
    }
}
