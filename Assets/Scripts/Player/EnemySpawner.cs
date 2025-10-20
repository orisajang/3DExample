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

    private void Awake()
    {
        // + Spanw이 랜덤위치에서 나오도록
        // + 오브젝트 풀로
        // + 코루틴 및 Invoke 두가지경우 가능하도록
    }
    private void Update()
    {
        //RemoteCoroutine(); //코루틴 제어
        GameManagerScript.Instance.RemoteCoroutine(leftPosX, rightPosX, leftEndPosZ);
    }

}
