using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreateEnemyBuf : MonoBehaviour
{
    Coroutine _coroutine;
    [SerializeField] GameObject prefabObj;

    private void Awake()
    {
        GameManagerScript.Instance._unityEvent.AddListener(MakeObjFunc);
    }

    private void MakeObjFunc()
    {
        if(_coroutine == null)
        {
            Debug.Log("内风凭 惯积");
            _coroutine = StartCoroutine(MakeObj(prefabObj));
        }
    }

    IEnumerator MakeObj(GameObject obj)
    {
        Instantiate(obj, transform.position, Quaternion.Euler(transform.position));
        Debug.Log("积己");
        yield return null;
    }

}
