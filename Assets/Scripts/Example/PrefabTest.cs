using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTest : MonoBehaviour
{
    [SerializeField] private List<GameObject> _prefabs = new List<GameObject>();

    private void Start()
    {
        PrintPrefabsName();
    }
    private void PrintPrefabsName()
    {
        foreach(var pre in _prefabs)
        {
            Debug.Log(pre.name);
        }
    }
}
