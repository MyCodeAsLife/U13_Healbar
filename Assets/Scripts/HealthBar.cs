using UnityEngine;

[RequireComponent(typeof(Character))]
public abstract class HealthBar : MonoBehaviour
{
    private Character _character;

    private void Start()
    {
        _character = GetComponent<Character>();
        _character.SubscribeHealthChanged(ChangeHealth);
        ChangeHealth(_character.CurrentHealth, _character.MaxHealth);
    }

    private void OnDisable()
    {
        _character.UnsubscribeHealthChanged(ChangeHealth);
    }

    protected abstract void ChangeHealth(float currentHealth, float maxHealth);
}
