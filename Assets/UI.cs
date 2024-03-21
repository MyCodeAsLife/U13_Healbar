using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Character))]
public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthBar1;
    [SerializeField] private Slider _healthBar3;

    private Character _character;
    private Coroutine _changesSmoothly;

    private void OnDisable()
    {
        _character.UnsubscribeHeathChanged(ChangeHealth);
        _character.UnsubscribeMaxHeathChanged(ChangeMaxHealth);
    }

    private void Start()
    {
        _character = GetComponent<Character>();
        _character.SubscribeHeathChanged(ChangeHealth);
        _character.SubscribeMaxHeathChanged(ChangeMaxHealth);

        ChangeMaxHealth(_character.MaxHealth);
        ChangeHealth(_character.Health);
    }

    private void ChangeHealth(float healthPoint)
    {
        _healthBar1.text = healthPoint.ToString() + '/' + _character.MaxHealth.ToString();

        if (_changesSmoothly != null)
            StopCoroutine(_changesSmoothly);

        _changesSmoothly = StartCoroutine(ChangesSmoothly(healthPoint));
    }

    private void ChangeMaxHealth(float maxHealthPoint)
    {
        _healthBar1.text = _character.Health.ToString() + '/' + maxHealthPoint;
        _healthBar3.maxValue = maxHealthPoint;
    }

    private IEnumerator ChangesSmoothly(float healthPoint)
    {
        float speed = 50;

        while (_healthBar3.value != healthPoint)
        {
            _healthBar3.value = Mathf.MoveTowards(_healthBar3.value, healthPoint, speed * Time.deltaTime);
            yield return null;
        }

        _changesSmoothly = null;
    }
}
