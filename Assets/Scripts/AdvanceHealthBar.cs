using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Character))]
public class AdvancedHealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;

    private Character _character;
    private Coroutine _changesSmoothly;

    private void OnDisable()
    {
        _character.UnsubscribeHealthChanged(ChangeHealth);
    }

    private void Start()
    {
        _character = GetComponent<Character>();
        _character.SubscribeHealthChanged(ChangeHealth);
        ChangeHealth(_character.CurrentProcentHealth);
    }

    private void ChangeHealth(float procentHealth)
    {
        if (_changesSmoothly != null)
            StopCoroutine(_changesSmoothly);

        _changesSmoothly = StartCoroutine(ChangesSmoothly(procentHealth));
    }

    private IEnumerator ChangesSmoothly(float healthPoint)
    {
        float speed = 1;

        while (_healthBar.value != healthPoint)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, healthPoint, speed * Time.deltaTime);
            yield return null;
        }

        _changesSmoothly = null;
    }
}
