using System;
using UnityEngine;

public class Character : MonoBehaviour, IDamageble, IHealable
{
    private Health _health;

    public float Health { get { return _health.Value; } }
    public float MaxHealth { get { return _health.MaxValue; } }

    private void Awake()
    {
        float startHealth = 100;

        _health = new Health(startHealth);
    }

    public void TakeDamage(float damage)
    {
        _health.Decrease(damage);
    }

    public void TakeHealing(float healing)
    {
        _health.Increase(healing);
    }

    public void SubscribeHeathChanged(Action<float> function)
    {
        _health.HealthChanged += function;
    }

    public void SubscribeMaxHeathChanged(Action<float> function)
    {
        _health.MaxHealthChanged += function;
    }

    public void UnsubscribeHeathChanged(Action<float> function)
    {
        _health.HealthChanged -= function;
    }

    public void UnsubscribeMaxHeathChanged(Action<float> function)
    {
        _health.MaxHealthChanged -= function;
    }
}
