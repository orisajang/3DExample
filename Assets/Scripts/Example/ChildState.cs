using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildState : MonoBehaviour
{
    public void SetName(string text)
    {
        gameObject.name = text;
    }
    public void PrintParent()
    {
        Debug.Log($"{gameObject.name}: {gameObject.transform.parent.name}");
    }
}
