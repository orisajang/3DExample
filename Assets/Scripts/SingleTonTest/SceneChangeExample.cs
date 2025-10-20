using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeExample : MonoBehaviour
{
    void Start() //파괴되지않도록
    {
        DontDestroyOnLoad(gameObject); //씬 불러올때마다 파괴가 안되므로 씬 불러올때마다 계속 생김...
    }
    void Update() //업데이트에서 입력받아서 씬전환
    {
        if(Input.GetKeyUp(KeyCode.Alpha1)) SceneManager.LoadScene(0);
        if (Input.GetKeyUp(KeyCode.Alpha2)) SceneManager.LoadScene(1);
        if (Input.GetKeyUp(KeyCode.Alpha3)) SceneManager.LoadScene(2);
    }
}
