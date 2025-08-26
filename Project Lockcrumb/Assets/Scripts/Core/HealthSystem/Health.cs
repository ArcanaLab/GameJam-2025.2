using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Health : MonoBehaviour
/// <summary>
/// Manages the health system for an entity, including current and maximum health, 
/// invincibility frames (iframes), and death state. 
/// Provides events for health changes, healing, damage, and death.
/// </summary>
/// <remarks>
/// Features to be implemented:
/// - Differentiation between friendly and enemy damage
/// - Resistance and weakness system
/// - Armor system
/// </remarks>
{
    [Header("Health Settings")]

    [SerializeField] private int _maxHealth = 100;
    private int _currentHealth;
    private bool _isDead = false;
    public bool HasIframes = false; // If true, entity has the hability to have invincibility frames after taking damage
    private bool _isInIframes => _iframeTimer > 0;
    [SerializeField] private float _iframeDuration = 1f;
    private float _iframeTimer = 0f;


    //Todo: Add diferenzation between frendly and enemy damage
    //Todo: Add resistance and weakness system
    //Todo: Add armor system
    public event Action<float> OnHealthChanged; // float parameter to indicate health percentage
    public event Action<float> OnHealed;
    public event Action<float> OnDamaged;
    public event Action OnDeath;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }
    private void Update()
    {
        if (HasIframes && _iframeTimer > 0)
        {
            _iframeTimer -= Time.deltaTime;
            if (_iframeTimer < 0) _iframeTimer = 0;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        if (_isDead || damageAmount <= 0 || _isInIframes) return;


        _currentHealth -= damageAmount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);

        OnDamaged?.Invoke(damageAmount);
        OnHealthChanged?.Invoke((float)_currentHealth / _maxHealth);
        // Activar iframes después de recibir daño
        if (HasIframes)
            _iframeTimer = _iframeDuration;

        if (_currentHealth <= 0)
        {
            Die();
        }
    }
    public void Heal(int healAmount)
    {
        if (_isDead || healAmount <= 0) return;

        _currentHealth += healAmount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);

        OnHealed?.Invoke(healAmount);
        OnHealthChanged?.Invoke((float)_currentHealth / _maxHealth);
    }

    private void Die()
    {
        if (_isDead) return;

        _isDead = true;
        OnDeath?.Invoke();
        Debug.Log($"{gameObject.name} has died.");
    }
    
}
