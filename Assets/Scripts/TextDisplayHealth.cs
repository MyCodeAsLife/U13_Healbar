using TMPro;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class TextDisplayHealth : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _displayHealth;

    private Character _character;

    private void OnDisable()
    {
        _character.UnsubscribeHealthChanged(ChangeHealth);
    }

    private void Start()
    {
        _character = GetComponent<Character>();
        _character.SubscribeHealthChanged(ChangeHealth);
        ChangeHealth(_character.CurrentHealth);
    }

    private void ChangeHealth(float healthPoint)
    {
        _displayHealth.text = _character.CurrentHealth.ToString() + '/' + _character.MaxHealth.ToString();
    }
}