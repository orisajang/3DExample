using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManagerScript : MonoBehaviour
{
    //총알, 적, 기타 게임 오브젝트의 생성과 파괴를 관리하는 매니저 설계 + 유니티 이벤트
    //오브젝트 풀 + 매니저 중심
    //오브젝트 풀 관리, 생성, 삭제는 싱글톤에서 담당
    //생성은 매니저, 삭제(비활성화)는 각각의 객체에서 해도 된다고함

    //1. 일단 유일한 싱글톤 패턴으로 오브젝트 생성
    private static GameManagerScript _instance;
    public static GameManagerScript Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManagerScript>();
                if (_instance == null)
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
        EnemyInit();
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
            DontDestroyOnLoad(_instance);
        }
    }


    //2. 총알 발사 코드
    [SerializeField] GameObject bulletPrefab;
    public void ShootBullet(Vector3 bulletPosition, Quaternion bulletRotation)
    {
        if (bulletPrefab != null)
        {
            Vector3 onePos = new Vector3(bulletPosition.x, bulletPosition.y, bulletPosition.z);
            Instantiate(bulletPrefab, onePos, bulletRotation, null);
        }
    }
    //3. 적 생성 코드
    [SerializeField] GameObject enemyPrefab;
    GameObject[] _enemyPool;    //오브젝트 풀
    [SerializeField] int poolLength = 3; //오브젝트 풀 사이즈
    [SerializeField] float enemyDelayTime = 2.0f;
    WaitForSeconds _delay;      //코루틴 딜레이
    Coroutine _spawnCoroutine;  //코루틴
    private void EnemyInit()
    {
        // + Spanw이 랜덤위치에서 나오도록
        // + 오브젝트 풀로
        // + 코루틴 및 Invoke 두가지경우 가능하도록
        _delay = new WaitForSeconds(enemyDelayTime);
        _enemyPool = new GameObject[poolLength];
        for (int i = 0; i < poolLength; i++)
        {
            _enemyPool[i] = Instantiate(enemyPrefab, transform.position, enemyPrefab.transform.rotation, transform);
            _enemyPool[i].SetActive(false);
        }
    }
    public void RemoteCoroutine(Transform leftPosX, Transform rightPosX, Transform leftEndPosZ)
    {
        if (_spawnCoroutine == null)
        {
            Debug.Log("코루틴 시작");
            _spawnCoroutine = StartCoroutine(CoroutineRepeating(leftPosX, rightPosX, leftEndPosZ)); //2. Coroutine 방법 
        }
        if (Input.GetKeyDown(KeyCode.Q)) //코루틴 종료
        {
            StopCoroutine(_spawnCoroutine);
            _spawnCoroutine = null;
        }
    }
    IEnumerator CoroutineRepeating(Transform leftPosX, Transform rightPosX, Transform leftEndPosZ) //코루틴으로 Enemy 반복 생성
    {
        while (true)
        {
            if (GameManager.Instance.IsPlaying)
            {
                float rndRange = Random.Range(leftPosX.position.x, rightPosX.position.x); //-4 ~ 4
                Vector3 pos = new Vector3(transform.position.x + rndRange, transform.position.y, transform.position.z);
                int poolIndex = GetPoolEmptyIndex(); //비어있는 오브젝트풀 인덱스를 가져옴 (없을경우 -1)
                if (poolIndex != -1) //비어있는 오브젝트풀 인덱스가 잇을경우 if문안에서 생성
                {
                    _enemyPool[poolIndex] = Instantiate(enemyPrefab, pos, enemyPrefab.transform.rotation, transform);
                    GameObject obj = _enemyPool[poolIndex]; // 풀에서 오브젝트 가져오기
                    EnemyMinion enemyMinion = obj.GetComponent<EnemyMinion>();
                    enemyMinion.SetLeftEndPos(leftEndPosZ);
                }
            }
            yield return _delay;
        }
    }
    private int GetPoolEmptyIndex() //오브젝트풀 형태의 최대길이를 넘어서지 않을때만 생성
    {
        for (int i = 0; i < _enemyPool.Length; i++)
        {
            if (!_enemyPool[i].activeSelf) //현재 비활성화 된 상태라면
            {
                return i;
            }
        }
        return -1;  //오브젝트풀이 비어있지않다면 -1 반환
    }

    //4. 유니티 이벤트로 이벤트 지정
    [field:SerializeField] public UnityEvent _unityEvent { get; private set; }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("C키 눌림");
            _unityEvent?.Invoke();
        }
    }

    private void OnEnable()
    {
        Bullet.OnBulletHit += ReturnBulletEvent;
    }

    private void OnDisable()
    {
        Bullet.OnBulletHit -= ReturnBulletEvent;
    }
    private void ReturnBulletEvent(Bullet bullet)
    {
        Debug.Log("총알 비활성화!!");
        bullet.gameObject.SetActive(false);
    }


}
