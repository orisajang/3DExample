using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform weaponPosition;

    [SerializeField] private float _autoShotDelay; //레이를 쏴서 적이 있을떄만 총알 자동발사 실습 //Weapon클래스를 상속받도록 해서 해보기
    [SerializeField] private float _autoShotDistance; //레이를 쏴서 적이 있을떄만 총알 자동발사 실습 //Weapon클래스를 상속받도록 해서 해보기
    private float _autoShotCoolTime;

    private void AutoShot() //레이캐스트를 이용한 총알 자동발사 기능
    {
        if(_autoShotCoolTime > 0)
        {
            _autoShotCoolTime -= Time.deltaTime;
            return;
        }
        Ray ray = new Ray(transform.position, transform.forward);
        bool isHit = Physics.Raycast(ray, out RaycastHit hitInfo, _autoShotDistance);
        if(isHit)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                ShootMultiple();
                _autoShotCoolTime = _autoShotDelay;
            }
        }
    }
    private void OnDrawGizmos() //시각적 테스트를 위한 기즈모
    {
        Gizmos.color = Color.red;
        Vector3 startPoint = transform.position;
        Vector3 endPoint = transform.position + transform.forward * _autoShotDistance;
        Gizmos.DrawLine(startPoint, endPoint);
    }
    private void Update()
    {
        AutoShot();
    }


    public void ShootBullet()
    {
        if(bulletPrefab != null)
        {
            Vector3 onePos = new Vector3(weaponPosition.position.x, weaponPosition.position.y, weaponPosition.position.z);
            Instantiate(bulletPrefab, onePos, weaponPosition.rotation, null);
        }
    }
    public void ShootMultiple()
    {
        if (bulletPrefab != null)
        {
            Vector3 onePos = new Vector3(weaponPosition.position.x - 2, weaponPosition.position.y, weaponPosition.position.z);
            Vector3 twoPos = new Vector3(weaponPosition.position.x, weaponPosition.position.y, weaponPosition.position.z);
            Vector3 threePos = new Vector3(weaponPosition.position.x + 2, weaponPosition.position.y, weaponPosition.position.z);
            Vector3 oneRotation = new Vector3(weaponPosition.rotation.x - 2, weaponPosition.position.y, weaponPosition.position.z);
            Vector3 twoRotation = new Vector3(weaponPosition.rotation.x, weaponPosition.position.y, weaponPosition.position.z);
            Vector3 threeRotation = new Vector3(weaponPosition.rotation.x + 2, weaponPosition.position.y, weaponPosition.position.z);

            Instantiate(bulletPrefab, onePos, Quaternion.Euler(oneRotation), null);
            Instantiate(bulletPrefab, twoPos, Quaternion.Euler(twoRotation), null);
            Instantiate(bulletPrefab, threePos, Quaternion.Euler(threeRotation), null);
        }
    }
}
