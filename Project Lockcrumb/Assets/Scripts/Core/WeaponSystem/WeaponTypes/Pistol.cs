using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    public override void Shoot()
    {
        base.Shoot();
        if (bulletsOnMagazine > 0)
        {

            var _bulletGameObject = Instantiate(BulletPrefab, shooter.transform.position ,  shooter.transform.rotation, _bulletPool);
            _bulletGameObject.name = BulletPrefab.name;
            bulletsOnMagazine--;
        }
        else
        {
            Debug.Log("Out of ammo! Reload!");
        }
    }
}
