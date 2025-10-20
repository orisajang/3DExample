using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform weaponPosition;
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
