using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponProperties properties;

    [SerializeField] protected GameObject shooter;
    public WeaponProperties Properties
    {
        get => properties;
        set => properties = value;
    }
    public GameObject BulletPrefab => _bulletGameObject;
    [SerializeField] private GameObject _bulletGameObject;
    protected int bulletsOnMagazine;
    protected int currentAmmoOnReserve;


    private const string BULLET_POOL_TAG = "Bullet Pool";
    protected Transform _bulletPool;

    public void Start()
    {
        bulletsOnMagazine = properties.MagazineSize;
        currentAmmoOnReserve = properties.AmmoOnReserve;
        _bulletPool = GameObject.FindGameObjectWithTag(BULLET_POOL_TAG).transform;
    }
    public void Reload()
    {
        Debug.Log("Reloading...");
        int _bulletsToReload = properties.MagazineSize - bulletsOnMagazine;
        if (currentAmmoOnReserve >= _bulletsToReload)
        {
            bulletsOnMagazine += _bulletsToReload;
            currentAmmoOnReserve -= _bulletsToReload;
        }
        else
        {
            bulletsOnMagazine += currentAmmoOnReserve;
            currentAmmoOnReserve = 0;
        }

    }

    public virtual void Shoot() => Debug.Log("Pew Pew!");

}
