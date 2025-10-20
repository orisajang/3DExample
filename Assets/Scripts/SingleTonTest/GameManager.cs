using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : Singleton<GameManager>
{
    private bool _isPlaying = false;

    public bool IsPlaying { get { return _isPlaying; } }
    public event Action OnGameStartAction;
    [field: SerializeField] public UnityEvent OnGameEndAction { get; private set; } = new UnityEvent();

    //현재 게임이 진행중인지 여부를 전환하는 함수
    public void ChangeGameState()
    {
        _isPlaying = !_isPlaying;

        if (_isPlaying) OnGameStartAction?.Invoke();
        else OnGameEndAction?.Invoke();
    }
}
