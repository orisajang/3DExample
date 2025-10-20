using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroyObj : MonoBehaviour
{
    [SerializeField] private float _destroyDelay;
    private float _aliveTime = 0f;

    // Update is called once per frame
    void Update()
    {
        _aliveTime += Time.deltaTime;
        CheckSelfDestroy();
    }
    private void CheckSelfDestroy()
    {
        if(_aliveTime >= _destroyDelay)
        {
            Destroy(gameObject);
        }
    }
}
