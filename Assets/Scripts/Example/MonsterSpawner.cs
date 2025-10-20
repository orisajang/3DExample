using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _monsterPrefab;
    [SerializeField][Range(0, 5)] private float _positionScope;

    private Queue<GameObject> _monsters = new Queue<GameObject>();
    private int _spawnCount = 0;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Spawn(); //����
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            DeSpawn(); //����
        }
    }

    private void Spawn()
    {
        GameObject monster = Instantiate(_monsterPrefab,RandPos(),transform.rotation);
        _monsters.Enqueue(monster);
        monster.name = $"Monster - {_spawnCount++}";
    }
    private void DeSpawn()
    {
        if(_monsters.Count > 0)
        {
            Destroy(_monsters.Dequeue());
        }
    }

    private Vector3 RandPos() //������ ��ġ�� �����ǰ� �ϱ�
    {
        Vector3 pos = new Vector3(
            Random.Range(-_positionScope, _positionScope),
            0f,
            Random.Range(-_positionScope, _positionScope)
            );
        return pos;
    }
}
