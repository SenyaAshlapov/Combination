using UnityEngine;

[CreateAssetMenu(fileName = "HealthData", menuName = "Combination/HealthData", order = 0)]
public class HealthData : ScriptableObject 
{
    public delegate void HealthAction(Sprite sprite, Color32 color);
    public static HealthAction UpdateHealthAbilityUI;

    public Sprite Icon;
    public Color32 Color;
    public Sprite DefaultIcon;
    public Color32 DefaultColor;
    public float Health;

    public void InitHealth(){
        UpdateHealthAbilityUI?.Invoke(Icon, Color);
    }
    public float UseHealth(){
        UpdateHealthAbilityUI?.Invoke(DefaultIcon, DefaultColor);
        return Health;
    }
}
