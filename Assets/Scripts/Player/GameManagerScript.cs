using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManagerScript : MonoBehaviour
{
    //총알, 적, 기타 게임 오브젝트의 생성과 파괴를 관리하는 매니저 설계
    //오브젝트 풀 + 매니저 중심
    //오브젝트 풀은 enemy에서 가지고있게 할까?
    //생성은 매니저, 삭제(비활성화)는 각각의 객체에서 해도 된다고함
    //1. 총알 발사 코드
    [SerializeField] GameObject bulletPrefab;
    public void ShootBullet(Vector3 bulletPosition, Quaternion bulletRotation)
    {
        if (bulletPrefab != null)
        {
            Vector3 onePos = new Vector3(bulletPosition.x, bulletPosition.y, bulletPosition.z);
            Instantiate(bulletPrefab, onePos, bulletRotation, null);
        }
    }


    //2. 유니티 이벤트로 이벤트 지정
    [field:SerializeField] public UnityEvent _unityEvent { get; private set; }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("C키 눌림");
            _unityEvent?.Invoke();
        }
    }

    //1. 일단 유일한 싱글톤 패턴으로 오브젝트 생성
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
