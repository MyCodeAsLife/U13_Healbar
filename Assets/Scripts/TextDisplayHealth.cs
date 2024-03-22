using TMPro;
using UnityEngine;

public class TextDisplayHealth : HealthBar
{
    [SerializeField] private TextMeshProUGUI _displayHealth;

    protected override void ChangeHealth(float currentHealth, float maxHealth)
    {
        _displayHealth.text = currentHealth.ToString() + '/' + maxHealth.ToString();
    }
}