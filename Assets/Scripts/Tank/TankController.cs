using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private Transform _muzzleTransform;
    [SerializeField] private GameObject _cannonBallPrefab;
    [SerializeField] private int _cannonBallPoolSize;

    private Rigidbody _rigidbody;
    private GameObject[] _cannonBallPool;

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        MoveObject();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShotCannon();
        }
    }

    private void Init()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _cannonBallPool = new GameObject[_cannonBallPoolSize];
        for (int i = 0; i < _cannonBallPool.Length; i++)
        {
            _cannonBallPool[i] = Instantiate(_cannonBallPrefab);
            _cannonBallPool[i].SetActive(false);
        }
    }

    private void MoveObject()
    {
        Vector3 direction = GetNormalizedDirection();
        if (direction == Vector3.zero)
        {
            return;
        }

        SetRotateLerp(direction);
        SetFowardVelocity(_moveSpeed);
    }

    private void SetRotateLerp(Vector3 direction)
    {
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            Quaternion.LookRotation(direction),
            _rotateSpeed * Time.deltaTime
            );
    }

    private void SetFowardVelocity(float value)
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

    private void ShotCannon()
    {
        foreach (var ball in _cannonBallPool)
        {
            if (ball.activeSelf == false)
            {
                ball.transform.position = _muzzleTransform.position;
                ball.transform.rotation = _muzzleTransform.rotation;
                ball.SetActive(true);
                return;
            }
        }
    }

}
