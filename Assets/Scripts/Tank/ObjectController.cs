using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    [SerializeField] private float _force;
    private Rigidbody _rigidbody;
    [SerializeField] private List<GameObject> _ignoreObjects = new List<GameObject>();

    private void Awake()
    {
        Init();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(transform.forward * _force, ForceMode.Impulse);
        }
    }

    private void Init()
    {
        _rigidbody = GetComponent<Rigidbody>();
        foreach(GameObject obj in _ignoreObjects)
        {
            Physics.IgnoreLayerCollision(gameObject.layer, obj.layer, true);
        }
    }
}
