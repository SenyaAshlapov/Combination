using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CombatAbilityData", menuName = "Combination/CombatAbilityData", order = 0)]
public class CombatAbilityData : ScriptableObject
{
    public delegate void combatAbilityAction(Sprite sprite, Color32 color);
    public static combatAbilityAction UpdateCombatAbilityUI;
    public float CoolDown;
    public GameObject WingsPrefab;
    public GameObject DamagerPrefab;
    public Sprite Icon;
    public Color32 Color;

    [TextArea]
    public string Description;

    public void RenderCombatAbility(Transform renderPosition)
    {
        foreach (Transform child in renderPosition)
        {
            Destroy(child.gameObject);
        }
        Instantiate(WingsPrefab, renderPosition);
    }

    public virtual void ActivateCombatAbility(Transform shotTransform)
    {
        Instantiate(DamagerPrefab, shotTransform.position, shotTransform.rotation);
    }

    public void updateCombatUI()
    {        
        UpdateCombatAbilityUI?.Invoke(Icon, Color);
    }




}
