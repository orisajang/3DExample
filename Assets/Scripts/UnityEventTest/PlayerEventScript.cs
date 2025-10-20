using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEventScript : MonoBehaviour
{
    [field: SerializeField] public UnityEvent OnPetCalled { get; private set; } = new UnityEvent();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) CallPet();
    }
    private void CallPet()
    {
        OnPetCalled?.Invoke();
    }
}
