
using UnityEngine;
[CreateAssetMenu(fileName = "WeaponStats", menuName = "ScriptableObjects/WeaponStats")]
public class WeaponProperties : ScriptableObject
{
    [Header("Core Stats")]
    public string displayName = "Test Weapon";

    [SerializeField] private float fireRate = 1f;
    public float FireRate => fireRate;

    [SerializeField] private int magazineSize = 10;
    public int MagazineSize => magazineSize;

    [SerializeField] private int ammoOnReserve = 50;
    public int AmmoOnReserve => ammoOnReserve;
    [SerializeField] private bool isAutomatic = false;
    public bool IsAutomatic => isAutomatic;
    [Header("Reload")]
    [SerializeField] private float reloadTime = 2f;
    public float ReloadTime => reloadTime;
    [SerializeField] private Vector2 perfectReloadWindow = new(0.5f, 1f);
    public Vector2 PerfectReloadWindow => perfectReloadWindow;
  
}
