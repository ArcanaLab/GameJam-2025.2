using UnityEngine;

[CreateAssetMenu(fileName = "BulletProperties", menuName = "ScriptableObjects/BulletProperties")]
public class BulletProperties : ScriptableObject
{
    [Header("Core Stats")]
    public string displayName = "Bullet";

    [SerializeField]
    private float speed = 10f;
    public float Speed => speed;

    [SerializeField]
    private float lifetime = 5f;
    public float Lifetime => lifetime;
}
