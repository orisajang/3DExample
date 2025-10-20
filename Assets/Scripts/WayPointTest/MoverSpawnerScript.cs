using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoverSpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject _moverPrefab; //소환할 대상 프리팹
    [SerializeField] private Transform _waypointBox; //웨이포인트 정보 (소환대상에게 전달)
    [SerializeField] private float _spawnDelay; //소환 간격

    private void Start()
    {
        StartCoroutine(SpawnMover());
    }
    private IEnumerator SpawnMover() //소환 코루틴 함수
    {
        if (_waypointBox == null) yield break;

        while(true) //계속 소환
        {
            GameObject newMoverObj = Instantiate(_moverPrefab, transform); //새 객체 생성
            WaypointMoverScript newMover = newMoverObj.GetComponent<WaypointMoverScript>(); //객체에서 컴포넌트 가져옴
            newMover?.SetWayPointBox(_waypointBox); //이동할 위치 전달
            yield return new WaitForSeconds(_spawnDelay);
        }
    }
}
