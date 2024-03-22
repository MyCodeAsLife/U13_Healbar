using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Character))]
public class HealtBar : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;

    private Character _character;

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
        _healthBar.value = procentHealth;
    }
}
