using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTestScript : MonoBehaviour
{
    Coroutine coroutine;
    WaitForSeconds seconds = new WaitForSeconds(1);
    // Start is called before the first frame update
    void Start()
    {
        //coroutine = StartCoroutine(AA());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if( coroutine == null)
            {
                coroutine = StartCoroutine(AA());
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
                coroutine = null;
            }
        }
    }
    IEnumerator AA()
    {
        while(true)
        {
            Debug.Log("aa");
            yield return seconds;
        }
    }
}
