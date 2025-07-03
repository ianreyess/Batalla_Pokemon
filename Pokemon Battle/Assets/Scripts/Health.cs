using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Runtime.InteropServices.ComTypes;

public class Health : MonoBehaviour
{
    [SerializeField]
    private Slider _healthSlider;

    [SerializeField]
    private float _initialHealth = 200f;

    [SerializeField]
    private UnityEvent<float> _onUpdateHealth;

    [SerializeField]

    private UnityEvent _onDefeated;

    [SerializeField]

    private UnityEvent<DamageTarget> _onTakeDamage;

    private float _currentHealth;

    public float CurrentHealth => _currentHealth;

    public void InitialHealth()
    {
        _currentHealth = _initialHealth;
        UpdateHealth();
    }
    private void UpdateHealth()
    {
        _onUpdateHealth?.Invoke(_currentHealth / _initialHealth);
    }

    public void TakeDamage(DamageTarget damageTarget)
    {
        _currentHealth -= damageTarget.damage;
        _onTakeDamage?.Invoke(damageTarget);
        if (_currentHealth < 0)
        {
            _onDefeated?.Invoke();
            _currentHealth = 0;
            
        }
        UpdateHealth();
    }


}
