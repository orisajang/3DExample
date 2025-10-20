using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControllerScript : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    private Rigidbody _rigidbody;

    [SerializeField] private Transform _muzzleTransform;
    [SerializeField] private GameObject _cannonBallPrefab;
    [SerializeField] private int _cannonBallPoolSize;
    private GameObject[] _cannonBallPool;

    private void Awake()
    {
        Init();
    }
    private void Update()
    {
        ObjectMoving();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CannonShot();
        }
    }
    private void Init()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _cannonBallPool = new GameObject[_cannonBallPoolSize];
        for(int i=0; i< _cannonBallPool.Length; i++)
        {
            _cannonBallPool[i] = Instantiate(_cannonBallPrefab);
            _cannonBallPool[i].SetActive(false);
        }
    }
    private void ObjectMoving()
    {
        Vector3 direction = GetNormalizedDirection();
        if (direction == Vector3.zero) return;
        SetRotateLerp(direction);
        SetForwardVelocity(_moveSpeed);
    }
    private void SetRotateLerp(Vector3 direction) //회전을 Lerp로 부드럽게
    {
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            Quaternion.LookRotation(direction),
            _rotateSpeed * Time.deltaTime
            );
    }
    private void SetForwardVelocity(float value) //이동 함수
    {
        _rigidbody.velocity = transform.forward * value;
    }
    private Vector3 GetNormalizedDirection()
    {
        Vector3 inputDirection = Vector3.zero;
        inputDirection.x = Input.GetAxisRaw("Horizontal");
        inputDirection.z = Input.GetAxisRaw("Vertical");
        return inputDirection.normalized;
    }

    private void CannonShot()
    {
        foreach(var ball in _cannonBallPool)
        {
            if(!ball.activeSelf)
            {
                ball.transform.position = _muzzleTransform.position;
                ball.transform.rotation = Quaternion.LookRotation(_muzzleTransform.up);
                ball.SetActive(true);
                return;
                Debug.Log($"Up값은 {_muzzleTransform.up}"); 
            }
        }
    }
}
