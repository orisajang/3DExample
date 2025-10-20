using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManagerScript : MonoBehaviour
{
    //�Ѿ�, ��, ��Ÿ ���� ������Ʈ�� ������ �ı��� �����ϴ� �Ŵ��� ����
    //������Ʈ Ǯ + �Ŵ��� �߽�
    //������Ʈ Ǯ�� enemy���� �������ְ� �ұ�?
    //������ �Ŵ���, ����(��Ȱ��ȭ)�� ������ ��ü���� �ص� �ȴٰ���
    //1. �Ѿ� �߻� �ڵ�
    [SerializeField] GameObject bulletPrefab;
    public void ShootBullet(Vector3 bulletPosition, Quaternion bulletRotation)
    {
        if (bulletPrefab != null)
        {
            Vector3 onePos = new Vector3(bulletPosition.x, bulletPosition.y, bulletPosition.z);
            Instantiate(bulletPrefab, onePos, bulletRotation, null);
        }
    }


    //2. ����Ƽ �̺�Ʈ�� �̺�Ʈ ����
    [field:SerializeField] public UnityEvent _unityEvent { get; private set; }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("CŰ ����");
            _unityEvent?.Invoke();
        }
    }

    //1. �ϴ� ������ �̱��� �������� ������Ʈ ����
    private static GameManagerScript _instance;
    public static GameManagerScript Instance 
    { 
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<GameManagerScript>();
                if(_instance == null)
                {
                    _instance = new GameManagerScript();
                }
            }
            return _instance;
        } 
    }
    public void Awake()
    {
        Init();
    }
    private void Init()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

}
