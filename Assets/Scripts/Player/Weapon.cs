using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform weaponPosition;

    [SerializeField] private float _autoShotDelay; //���̸� ���� ���� �������� �Ѿ� �ڵ��߻� �ǽ� //WeaponŬ������ ��ӹ޵��� �ؼ� �غ���
    [SerializeField] private float _autoShotDistance; //���̸� ���� ���� �������� �Ѿ� �ڵ��߻� �ǽ� //WeaponŬ������ ��ӹ޵��� �ؼ� �غ���
    private float _autoShotCoolTime;

    private void AutoShot() //����ĳ��Ʈ�� �̿��� �Ѿ� �ڵ��߻� ���
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
    private void OnDrawGizmos() //�ð��� �׽�Ʈ�� ���� �����
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
