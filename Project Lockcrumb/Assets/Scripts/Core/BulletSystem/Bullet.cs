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
    private float _currentLifetime = 0f;

    private void Start()
    {
        _direction = transform.right; // Assuming the bullet's forward direction is along the x-axis
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Handle collision logic here (e.g., apply damage, destroy bullet)
        if (other.TryGetComponent<Health>(out Health health))
        {
            Debug.Log("Hit " + other.name + " for " + properties.Damage + " damage.");
            health.TakeDamage(properties.Damage);
        }
        Destroy(gameObject);
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


    public void Travel()
    {
        transform.position += properties.Speed * Time.deltaTime * _direction;
    }



}
