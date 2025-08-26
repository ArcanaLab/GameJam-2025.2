using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IBullet
{
    [SerializeField] private BulletProperties properties;

    public BulletProperties Properties
    {
        get => properties;
        set => properties = value;
    }

    private float _currentLifetime = 0f;

    public void Travel()
    {

        transform.position += properties.Speed * Time.deltaTime * Vector3.up;
    }
    
    private void Update()
    {
        Debug.Log("Bullet properties: " + properties.displayName + ", Speed: " + properties.Speed + ", Lifetime: " + properties.Lifetime);
        Travel();
        _currentLifetime += Time.deltaTime;
        if (_currentLifetime >= properties.Lifetime)
        {
            Destroy(gameObject);
        }
    }
}
