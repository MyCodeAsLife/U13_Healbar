using System;
using UnityEngine;

public class Character : MonoBehaviour, IDamageble, IHealable
{
    private Health _health;

    public float MaxHealth => _health.MaxValue;
    public float CurrentHealth => _health.Value;
    public float CurrentProcentHealth => _health.PercentValue;

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

    public void SubscribeHealthChanged(Action<float> function)
    {
        _health.OnChange += function;
    }

    public void UnsubscribeHealthChanged(Action<float> function)
    {
        _health.OnChange -= function;
    }
}
