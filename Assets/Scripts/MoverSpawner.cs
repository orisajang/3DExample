using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _moverPrefab; //소환될 대상 프리팹
    [SerializeField] private Transform _waypointBox; //소환 대상에게 전달할 웨이포인트 정보
    [SerializeField] private float _spawnDelay; //소환 간격

    private WaitForSeconds _delay;
    private void Start()
    {
        _delay = new WaitForSeconds(_spawnDelay);
        StartCoroutine(SpawnMover());
    }

    private IEnumerator SpawnMover() //소환에 사용할 코루틴 함수
    {
        if (_waypointBox == null)
            yield break;

        while (true) 
        {
            GameObject newMoverObj = Instantiate(_moverPrefab, transform); //새로운 객체 생성
            WayPointMover newMover = newMoverObj.GetComponent<WayPointMover>(); //생성한 객체에서 우리가 만든 웨이포인트 이동 컴포넌트 정보 가져옴
            newMover?.SetWayPointBox(_waypointBox); //이동할 위치들에 대한 정보를 전달

            yield return _delay; //정해진 시간 간격으로 동작하도록 설정
        }
    }
}
