using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerHpBar : MonoBehaviour, IPlayerHpObserver
{
    [SerializeField] private float _gap = 1.0f;
    [SerializeField] private Image _imgHpBar;
    //[SerializeField] private GameObject _target;
    [SerializeField] private Player _player;
    private Camera _camera;
    private Vector3 _gapPos;
    private void Awake()
    {
        IPlayerHpObserver aa = GetComponent<IPlayerHpObserver>();
        _player.AddHpObserver(aa);
    }
    private void OnDestroy()
    {
        _player.RemoveHpObserver(this);
    }
    private void Start()
    {
        Init();
    }

    private void Update()
    {
        MoveToTarget();
    }

    private void Init()
    {
        if (_camera == null) _camera = Camera.main;
        _gapPos = Vector3.forward * _gap;
    }

    public void OnPlayerHpChanged(float curHp, float maxHp)
    {
        _imgHpBar.fillAmount = curHp / maxHp;
    }
    private void MoveToTarget()
    {
        Vector3 movePos = _player.transform.position + _gapPos;
        transform.position = _camera.WorldToScreenPoint(movePos);
    }
}
