using UnityEngine;
using UnityEngine.UI;

public class SimpleHealtBar : HealthBar
{
    [SerializeField] private Slider _healthBar;

    protected override void ChangeHealth(float currentHealth, float maxHealth)
    {
        _healthBar.value = currentHealth / maxHealth;
    }
}
