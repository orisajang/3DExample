using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("<color=#fe6857> 플레이어와 닿았다 </color>");
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("<color=#fe6857> 플레이어와 닿아있다 </color>");
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("<color=#fe6857> 플레이어와 떨어졌다 </color>");
    }
}
