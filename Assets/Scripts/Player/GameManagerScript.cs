using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManagerScript : MonoBehaviour
{
    //�Ѿ�, ��, ��Ÿ ���� ������Ʈ�� ������ �ı��� �����ϴ� �Ŵ��� ���� + ����Ƽ �̺�Ʈ
    //������Ʈ Ǯ + �Ŵ��� �߽�
    //������Ʈ Ǯ ����, ����, ������ �̱��濡�� ���
    //������ �Ŵ���, ����(��Ȱ��ȭ)�� ������ ��ü���� �ص� �ȴٰ���

    //1. �ϴ� ������ �̱��� �������� ������Ʈ ����
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


    //2. �Ѿ� �߻� �ڵ�
    [SerializeField] GameObject bulletPrefab;
    public void ShootBullet(Vector3 bulletPosition, Quaternion bulletRotation)
    {
        if (bulletPrefab != null)
        {
            Vector3 onePos = new Vector3(bulletPosition.x, bulletPosition.y, bulletPosition.z);
            Instantiate(bulletPrefab, onePos, bulletRotation, null);
        }
    }
    //3. �� ���� �ڵ�
    [SerializeField] GameObject enemyPrefab;
    GameObject[] _enemyPool;    //������Ʈ Ǯ
    [SerializeField] int poolLength = 3; //������Ʈ Ǯ ������
    [SerializeField] float enemyDelayTime = 2.0f;
    WaitForSeconds _delay;      //�ڷ�ƾ ������
    Coroutine _spawnCoroutine;  //�ڷ�ƾ
    private void EnemyInit()
    {
        // + Spanw�� ������ġ���� ��������
        // + ������Ʈ Ǯ��
        // + �ڷ�ƾ �� Invoke �ΰ������ �����ϵ���
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
            Debug.Log("�ڷ�ƾ ����");
            _spawnCoroutine = StartCoroutine(CoroutineRepeating(leftPosX, rightPosX, leftEndPosZ)); //2. Coroutine ��� 
        }
        if (Input.GetKeyDown(KeyCode.Q)) //�ڷ�ƾ ����
        {
            StopCoroutine(_spawnCoroutine);
            _spawnCoroutine = null;
        }
    }
    IEnumerator CoroutineRepeating(Transform leftPosX, Transform rightPosX, Transform leftEndPosZ) //�ڷ�ƾ���� Enemy �ݺ� ����
    {
        while (true)
        {
            if (GameManager.Instance.IsPlaying)
            {
                float rndRange = Random.Range(leftPosX.position.x, rightPosX.position.x); //-4 ~ 4
                Vector3 pos = new Vector3(transform.position.x + rndRange, transform.position.y, transform.position.z);
                int poolIndex = GetPoolEmptyIndex(); //����ִ� ������ƮǮ �ε����� ������ (������� -1)
                if (poolIndex != -1) //����ִ� ������ƮǮ �ε����� ������� if���ȿ��� ����
                {
                    _enemyPool[poolIndex] = Instantiate(enemyPrefab, pos, enemyPrefab.transform.rotation, transform);
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
        for (int i = 0; i < _enemyPool.Length; i++)
        {
            if (!_enemyPool[i].activeSelf) //���� ��Ȱ��ȭ �� ���¶��
            {
                return i;
            }
        }
        return -1;  //������ƮǮ�� ��������ʴٸ� -1 ��ȯ
    }

    //4. ����Ƽ �̺�Ʈ�� �̺�Ʈ ����
    [field:SerializeField] public UnityEvent _unityEvent { get; private set; }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("CŰ ����");
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
        Debug.Log("�Ѿ� ��Ȱ��ȭ!!");
        bullet.gameObject.SetActive(false);
    }


}
