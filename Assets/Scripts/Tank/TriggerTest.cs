using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("<color=#fe6857> 플레이어가 영역으로 들어왔다 </color>");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("<color=#fe6857> 플레이어가 영역내 존재 </color>");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("<color=#fe6857> 플레이어가 영역에서 탈출 </color>");
        }
    }
}
