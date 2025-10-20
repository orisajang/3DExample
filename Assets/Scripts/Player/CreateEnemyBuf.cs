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
            Debug.Log("�ڷ�ƾ �߻�");
            _coroutine = StartCoroutine(MakeObj(prefabObj));
        }
    }

    IEnumerator MakeObj(GameObject obj)
    {
        Instantiate(obj, transform.position, Quaternion.Euler(transform.position));
        Debug.Log("����");
        yield return null;
    }

}
