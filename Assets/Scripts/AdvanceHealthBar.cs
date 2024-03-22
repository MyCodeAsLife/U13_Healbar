using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AdvancedHealthBar : HealthBar
{
    [SerializeField] private Slider _healthBar;

    private Coroutine _changesSmoothly;

    protected override void ChangeHealth(float currentHealth, float maxHealth)
    {
        if (_changesSmoothly != null)
            StopCoroutine(_changesSmoothly);

        _changesSmoothly = StartCoroutine(ChangesSmoothly(currentHealth, maxHealth));
    }

    private IEnumerator ChangesSmoothly(float curentHealth, float maxHealt)
    {
        float speed = 1;
        float value = curentHealth / maxHealt;

        while (_healthBar.value != value)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, value, speed * Time.deltaTime);
            yield return null;
        }

        _changesSmoothly = null;
    }
}
