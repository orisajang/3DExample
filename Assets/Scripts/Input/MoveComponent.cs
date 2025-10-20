using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputComponent))]
public class MoveComponent : MonoBehaviour
{
    [SerializeField] private GameObject _movingPlane; //범위 지정할 객체
    [SerializeField] private float _moveSpeed = 20;
    [SerializeField] private float _xBoundValue = 2f;
    [SerializeField] private float _zBoundValue = 3f;

    private InputComponent _inputComponent;
    private Vector3 _minWorldBounds;
    private Vector3 _maxWorldBounds;
    private Vector3 _playerExtents;

    private void Start()
    {
        _inputComponent = GetComponent<InputComponent>();

        SphereCollider playerColider = GetComponent<SphereCollider>();
        if (playerColider != null)
        {
            _playerExtents = playerColider.bounds.extents;
        }

        if (_movingPlane != null)
        {
            Bounds planeBounds = _movingPlane.GetComponent<MeshRenderer>().bounds;
            _minWorldBounds = planeBounds.center - planeBounds.extents;
            _maxWorldBounds = planeBounds.center + planeBounds.extents;
        }
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (!GameManager.Instance.IsPlaying) return;

        Vector3 inputVec = new Vector3(_inputComponent.HorInput, 0f, _inputComponent.VerInput).normalized;
        Vector3 deltaMovement = _moveSpeed * Time.deltaTime * inputVec;
        Vector3 nextPosition = transform.position + deltaMovement;

        float xGap = _xBoundValue * _playerExtents.x;
        float zGap = _zBoundValue * _playerExtents.z;

        nextPosition.x = Mathf.Clamp(nextPosition.x, _minWorldBounds.x + xGap, _maxWorldBounds.x - xGap);
        nextPosition.z = Mathf.Clamp(nextPosition.z, _minWorldBounds.z + zGap, _maxWorldBounds.z - zGap);
        transform.position = nextPosition;
    }
}