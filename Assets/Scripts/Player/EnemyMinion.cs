using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMinion : Enemy
{
    [SerializeField][Range(0, 1)] float _weight;
     Vector3 leftEndPosZ;
    private void Update()
    {
        //z위치 시작점을 찾아야함
        //방법1. 바운드 사용 (Singleton 및 여러 방법을 사용하려고보니 너무 어려워짐.)
        //방법2. 끝점을 알려주는 GameObject 생성

        if (leftEndPosZ == null) return;
        //방법2로 사용
        if (transform.position.z < leftEndPosZ.z)
        {
            Debug.Log($"z위치: {leftEndPosZ.z}");
            gameObject.SetActive(false);
        }
        transform.position += Vector3.back * (Time.deltaTime * _moveSpeed);
    }
    public void SetLeftEndPos(Transform leftEndPos)
    {
        leftEndPosZ = leftEndPos.position;
    }
}
