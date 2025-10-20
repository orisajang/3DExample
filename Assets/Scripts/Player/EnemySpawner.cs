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
    WaitForSeconds _delay;      //�ڷ�ƾ ������
    Coroutine _spawnCoroutine;  //�ڷ�ƾ
    GameObject[] _enemyPool;    //������Ʈ Ǯ

    private void Awake()
    {
        // + Spanw�� ������ġ���� ��������
        // + ������Ʈ Ǯ��
        // + �ڷ�ƾ �� Invoke �ΰ������ �����ϵ���
        _delay = new WaitForSeconds(_spawnTime);    //�ڷ�ƾ ������ ����
        _enemyPool = new GameObject[poolLength];    //������Ʈ Ǯ ����
        for(int i=0; i<poolLength; i++)
        {
            _enemyPool[i] = Instantiate(targetPrefab, transform.position, targetPrefab.transform.rotation, transform);
            _enemyPool[i].SetActive(false);
        }
    }

    void Start()
    {
        //InvokeRepeating(nameof(InstantiatePrefab), 1.0f, _spawnTime); //1. Invoke ���
    }
    private void Update()
    {
        RemoteCoroutine(); //�ڷ�ƾ ����
    }
    private void RemoteCoroutine()
    {
        if (_spawnCoroutine == null)
        {
            Debug.Log("�ڷ�ƾ ����");
            _spawnCoroutine = StartCoroutine(nameof(CoroutineRepeating)); //2. Coroutine ��� 
        }
        if (Input.GetKeyDown(KeyCode.Q)) //�ڷ�ƾ ����
        {
            StopCoroutine(_spawnCoroutine);
            _spawnCoroutine = null;
        }
    }
    IEnumerator CoroutineRepeating() //�ڷ�ƾ���� Enemy �ݺ� ����
    {
        while(true)
        {
            if(GameManager.Instance.IsPlaying)
            {
                Debug.Log("����");
                float rndRange = Random.Range(leftPosX.position.x, rightPosX.position.x); //-4 ~ 4
                Vector3 pos = new Vector3(transform.position.x + rndRange, transform.position.y, transform.position.z);
                int poolIndex = GetPoolEmptyIndex(); //����ִ� ������ƮǮ �ε����� ������ (������� -1)
                if (poolIndex != -1) //����ִ� ������ƮǮ �ε����� ������� if���ȿ��� ����
                {
                    /*
                    _enemyPool[poolIndex] = Instantiate(targetPrefab, pos, targetPrefab.transform.rotation, transform);
                    GameObject obj = _enemyPool[poolIndex]; // Ǯ���� ������Ʈ ��������
                    EnemyMinion enemyMinion = obj.GetComponent<EnemyMinion>();
                    enemyMinion.SetLeftEndPos(leftEndPosZ);
                    */
                    _enemyPool[poolIndex] = Instantiate(targetPrefab, pos, targetPrefab.transform.rotation, transform);
                    GameObject obj = _enemyPool[poolIndex]; // Ǯ���� ������Ʈ ��������
                    EnemyMinion enemyMinion = obj.GetComponent<EnemyMinion>();
                    enemyMinion.SetLeftEndPos(leftEndPosZ);
                }
            }
            yield return _delay;
        }
    }
    private int GetPoolEmptyIndex() //������ƮǮ ������ �ִ���̸� �Ѿ�� �������� ����
    {
        for(int i=0; i< _enemyPool.Length; i++)
        {
            if (!_enemyPool[i].activeSelf) //���� ��Ȱ��ȭ �� ���¶��
            {
                return i;
            }
        }
        return -1;  //������ƮǮ�� ��������ʴٸ� -1 ��ȯ
    }

    private void InstantiatePrefab() //Invoke�� ���̴� ���� �Լ�
    {
        float rndRange = Random.Range(-5, 5);
        Vector3 currentPos = transform.position;
        currentPos.x += rndRange;

        //���� ������ ���� + ����
        int poolIndex = GetPoolEmptyIndex();
        if (poolIndex != -1)
        {
            _enemyPool[poolIndex] = Instantiate(targetPrefab, currentPos, targetPrefab.transform.rotation, transform);
        }
    }

}
