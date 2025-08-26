using UnityEngine;


public class Bullet : MonoBehaviour, IBullet
{
    [SerializeField] private BulletProperties properties;

    public BulletProperties Properties
    {
        get => properties;
        set => properties = value;
    }

    private Vector3 _direction;

    private void Start()
    {
        _direction = transform.right; // Assuming the bullet's forward direction is along the x-axis
    }

    private float _currentLifetime = 0f;

    public void Travel()
    {
        transform.position += properties.Speed * Time.deltaTime * _direction;
    }
    
    private void Update()
    {
        Travel();
        _currentLifetime += Time.deltaTime;
        if (_currentLifetime >= properties.Lifetime)
        {
            Destroy(gameObject);
        }
    }
}
