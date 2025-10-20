using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _maxHp;
    [SerializeField] private Transform _trfStartPos;
    [SerializeField] private Transform _shotPos;
    private Weapon _weapon;


    private List<GameObject> bulletPool; //오브젝트 풀 쓰기
    private float _curHp;

    private void Awake()
    {
        _weapon = GetComponent<Weapon>();
        //InitPlayer();
        RegistPlayer();
    }

    private void RegistPlayer()
    {
        GameManager.Instance.OnGameStartAction += InitPlayer;
    }

    private void InitPlayer()
    {
        _curHp = _maxHp;
        transform.position = _trfStartPos.position;
        gameObject.SetActive(true);
    }
    public void OnTakeDamage(float damage)
    {
        _curHp -= damage;
        Debug.Log($"playerHp = {_curHp}");
        if (_curHp <= 0) 
        {
            GameManager.Instance.ChangeGameState();
            _curHp = 0;
            //gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //_weapon.ShootBullet(); //싱글톤에서 발사를 책임지도록 결정
            Debug.Log("발사");

            GameManagerScript.Instance.ShootBullet(_shotPos.position, _shotPos.rotation);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            _weapon.ShootMultiple();
        }
    }

}