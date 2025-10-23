using UnityEngine;
using UnityEngine.UI;

public class UIPlayerHpTopBar : MonoBehaviour, IPlayerHpObserver
{
    [SerializeField] private Image _imgHpBar; 
    [SerializeField] private Player _player;
    private void Awake()
    {
        _player.AddHpObserver(this);
    }
    private void OnDestroy()
    {
        _player.RemoveHpObserver(this);
    }
    public void OnPlayerHpChanged(float curHp, float maxHp)
    {
        _imgHpBar.fillAmount = curHp / maxHp;
    }
}
