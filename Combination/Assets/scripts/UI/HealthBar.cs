using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Color32 _colorRate1;
    [SerializeField] private Color32 _colorRate2;
    [SerializeField] private Color32 _colorRate3;
    [SerializeField] private Color32 _colorRate4;
    [SerializeField] private Color32 _colorRate5;

    [SerializeField] private Image _healthBar;

    private void Awake()
    {
        Player.UpdateHealthBar += updateHelthBar;
    }

    private void OnDestroy()
    {
        Player.UpdateHealthBar -= updateHelthBar;
    }

    private void updateHelthBar(float newHealth)
    {
        float newAmount = newHealth / 100;


        _healthBar.fillAmount = newAmount;

        if (newAmount < 1 && newAmount >= 0.8)
            _healthBar.color = _colorRate1;

        if (newAmount < 0.8 && newAmount >= 0.6)
            _healthBar.color = _colorRate2;

        if (newAmount < 0.6 && newAmount >= 0.4)
            _healthBar.color = _colorRate3;

        if (newAmount < 0.4 && newAmount >= 0.2)
            _healthBar.color = _colorRate4;


        if (newAmount < 0.2 && newAmount >= 0)
            _healthBar.color = _colorRate5;
    }
}
