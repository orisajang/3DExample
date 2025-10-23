using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    [SerializeField] private GameObject _characterPrefab;
    [SerializeField] private float _positionScope;
    private Camera _cam;
    private CharacterMoveScript _target;
    private Transform _targetTransform;
    private Ray _ray;

    private void Awake()
    {
        Init();
    }
    private void Update()
    {
        TryGetObjectHandle();
    }

    private void OnDrawGizmos() //기즈모로 _ray 선 표시
    {
        if(Input.GetMouseButton(0))
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(_ray.origin, _ray.direction * 20);
        }
    }

    private void Init() //초기화 (랜덤한 오브젝트 생성)
    {
        _cam = Camera.main;
        CreateObject(_characterPrefab).name = "Kim";
        CreateObject(_characterPrefab).name = "Lee";
        CreateObject(_characterPrefab).name = "Park";
    }

    private GameObject CreateObject(GameObject prefab) //랜덤위치에 오브젝트 생성
    {
        GameObject obj = Instantiate(prefab);
        obj.transform.position = new Vector3(
            Random.Range(-_positionScope, _positionScope),
            0f,
            Random.Range(-_positionScope, _positionScope));
        obj.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360),0);
        return obj;
    }
    
    private void TryGetObjectHandle() //선택한 오브젝트에 대한 제어권 획득
    {
        if(Input.GetMouseButton(0))
        {
            _ray = _cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(_ray,out hit))
            {
                if(_targetTransform == hit.transform)
                {
                    return;
                }
                if(_target != null)
                {
                    _target.IsSelect = false;
                }
                _targetTransform = hit.transform;
                _target = _targetTransform.GetComponent<CharacterMoveScript>();
                _target.IsSelect = true;
            }
        }
    }

}
