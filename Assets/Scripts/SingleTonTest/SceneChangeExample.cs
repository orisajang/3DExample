using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeExample : MonoBehaviour
{
    void Start() //�ı������ʵ���
    {
        DontDestroyOnLoad(gameObject); //�� �ҷ��ö����� �ı��� �ȵǹǷ� �� �ҷ��ö����� ��� ����...
    }
    void Update() //������Ʈ���� �Է¹޾Ƽ� ����ȯ
    {
        if(Input.GetKeyUp(KeyCode.Alpha1)) SceneManager.LoadScene(0);
        if (Input.GetKeyUp(KeyCode.Alpha2)) SceneManager.LoadScene(1);
        if (Input.GetKeyUp(KeyCode.Alpha3)) SceneManager.LoadScene(2);
    }
}
