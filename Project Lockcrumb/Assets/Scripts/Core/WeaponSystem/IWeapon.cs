using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    WeaponProperties Properties { get; set; }

    GameObject BulletPrefab { get;}
    void Shoot();
    IEnumerator Reload();
}
