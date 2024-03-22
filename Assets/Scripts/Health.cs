using System;
using UnityEngine;

public class Health
{
    private const float MinHealthPoint = 0f;

    private float _maxHealthPoint;
    private float _currentHealthPoint;

    public event Action<float, float> OnChange;

    public Health(float healthPoint)
    {
        _currentHealthPoint = healthPoint;
        _maxHealthPoint = healthPoint;
    }

    public Health(float currentHealthPoint, float maxHealthPoint)
    {
        _maxHealthPoint = maxHealthPoint;
        Change(currentHealthPoint);
    }

    public float Value { get { return _currentHealthPoint; } }
    public float MaxValue { get { return _maxHealthPoint; } }

    public void Increase(float healthPoint)
    {
        if (healthPoint > 0)
            Change(_currentHealthPoint + healthPoint);
    }

    public void Decrease(float healthPoint)
    {
        if (healthPoint > 0)
            Change(_currentHealthPoint - healthPoint);
    }

    public void ChangeMax(float maxHealthPoint)
    {
        if (maxHealthPoint > 0)
        {
            _maxHealthPoint = maxHealthPoint;
            Change(_currentHealthPoint);
        }
    }

    private void Change(float currentHealthPoint)
    {
        _currentHealthPoint = Mathf.Clamp(currentHealthPoint, MinHealthPoint, _maxHealthPoint);
        OnChange?.Invoke(_currentHealthPoint, _maxHealthPoint);
    }
}
