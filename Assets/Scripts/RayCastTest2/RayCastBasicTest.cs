using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastBasicTest : MonoBehaviour
{
    private RaycastHit[] _hitBuffer = new RaycastHit[10];
    [SerializeField] private float _distance = 10f;
    [SerializeField] private float _moveSpeed = 3f;
    private void Update()
    {
        MoveMethod(); //플레이어 이동 함수
        RayCastFirst(); //이걸 쓰면 1개만 가져온다
       // RayCastAllTest(); // 이 함수 주석 풀면 Raycast 여러개 가져올수있음
    }

    private void MoveMethod()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(x, 0, z).normalized;
        transform.position += direction * (Time.deltaTime * _moveSpeed);
    }

    private void RayCastFirst() //일반 레이캐스트 (처음 1개만 반환)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _distance))
        {
            Debug.Log("앞에 물체가있다! 이름:" + hit.collider.name);
            Debug.Log("거리: " + hit.distance);
            Debug.Log("point:" + hit.point); //충돌지점 월드좌표
            Debug.Log("gameObject.transform.position:" + hit.collider.gameObject.transform.position); //아래와 같음
            Debug.Log("transform.position:" + hit.transform.position); //위와 같은결과, 감지된 물체 위치

            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red, 1f);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * _distance, Color.green, 1f);
        }
    }
    private void RayCastAllTest()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if(Input.GetKeyDown(KeyCode.Z))
        {
            RaycastHit[] hits = Physics.RaycastAll(ray, _distance); //ray길이에서 100f만큼 있는 오브젝트들을 모두 저장
            Debug.Log($"[RaycastAll]충돌 개수:{hits.Length}");
            foreach(RaycastHit hit in hits)
            {
                Debug.Log($"Hits:{hit.collider.name}, Distance:{hit.distance}");
            }
        }

        if(Input.GetKeyDown(KeyCode.X)) //지금은 _hitBuffer가 10개이므로 10개만 설정가능
        {
            int hitCount = Physics.RaycastNonAlloc(ray, _hitBuffer, _distance);
            Debug.Log($"[RaycastNonAlloc]충돌개수: {hitCount}");
            for(int i=0; i<hitCount; i++)
            {
                Debug.Log($"Hits:{_hitBuffer[i].collider.name}, Distance:{_hitBuffer[i].distance}");
            }
        }

    }

}
