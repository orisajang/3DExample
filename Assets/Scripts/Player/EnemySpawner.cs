using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject targetPrefab;
    [SerializeField] float _spawnTime;
    [SerializeField] int poolLength = 3;
    [SerializeField] Transform leftPosX;
    [SerializeField] Transform rightPosX;
    [SerializeField] Transform leftEndPosZ;
    WaitForSeconds _delay;      //코루틴 딜레이
    Coroutine _spawnCoroutine;  //코루틴
    GameObject[] _enemyPool;    //오브젝트 풀

    private void Awake()
    {
        // + Spanw이 랜덤위치에서 나오도록
        // + 오브젝트 풀로
        // + 코루틴 및 Invoke 두가지경우 가능하도록
        _delay = new WaitForSeconds(_spawnTime);    //코루틴 딜레이 설정
        _enemyPool = new GameObject[poolLength];    //오브젝트 풀 길이
        for(int i=0; i<poolLength; i++)
        {
            _enemyPool[i] = Instantiate(targetPrefab, transform.position, targetPrefab.transform.rotation, transform);
            _enemyPool[i].SetActive(false);
        }
    }

    void Start()
    {
        //InvokeRepeating(nameof(InstantiatePrefab), 1.0f, _spawnTime); //1. Invoke 방법
    }
    private void Update()
    {
        RemoteCoroutine(); //코루틴 제어
    }
    private void RemoteCoroutine()
    {
        if (_spawnCoroutine == null)
        {
            Debug.Log("코루틴 시작");
            _spawnCoroutine = StartCoroutine(nameof(CoroutineRepeating)); //2. Coroutine 방법 
        }
        if (Input.GetKeyDown(KeyCode.Q)) //코루틴 종료
        {
            StopCoroutine(_spawnCoroutine);
            _spawnCoroutine = null;
        }
    }
    IEnumerator CoroutineRepeating() //코루틴으로 Enemy 반복 생성
    {
        while(true)
        {
            if(GameManager.Instance.IsPlaying)
            {
                Debug.Log("랜덤");
                float rndRange = Random.Range(leftPosX.position.x, rightPosX.position.x); //-4 ~ 4
                Vector3 pos = new Vector3(transform.position.x + rndRange, transform.position.y, transform.position.z);
                int poolIndex = GetPoolEmptyIndex(); //비어있는 오브젝트풀 인덱스를 가져옴 (없을경우 -1)
                if (poolIndex != -1) //비어있는 오브젝트풀 인덱스가 잇을경우 if문안에서 생성
                {
                    /*
                    _enemyPool[poolIndex] = Instantiate(targetPrefab, pos, targetPrefab.transform.rotation, transform);
                    GameObject obj = _enemyPool[poolIndex]; // 풀에서 오브젝트 가져오기
                    EnemyMinion enemyMinion = obj.GetComponent<EnemyMinion>();
                    enemyMinion.SetLeftEndPos(leftEndPosZ);
                    */
                    _enemyPool[poolIndex] = Instantiate(targetPrefab, pos, targetPrefab.transform.rotation, transform);
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
        for(int i=0; i< _enemyPool.Length; i++)
        {
            if (!_enemyPool[i].activeSelf) //현재 비활성화 된 상태라면
            {
                return i;
            }
        }
        return -1;  //오브젝트풀이 비어있지않다면 -1 반환
    }

    private void InstantiatePrefab() //Invoke에 쓰이는 생성 함수
    {
        float rndRange = Random.Range(-5, 5);
        Vector3 currentPos = transform.position;
        currentPos.x += rndRange;

        //생성 범위를 지정 + 생성
        int poolIndex = GetPoolEmptyIndex();
        if (poolIndex != -1)
        {
            _enemyPool[poolIndex] = Instantiate(targetPrefab, currentPos, targetPrefab.transform.rotation, transform);
        }
    }

}
