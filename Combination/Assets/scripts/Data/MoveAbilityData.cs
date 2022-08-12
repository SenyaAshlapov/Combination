using UnityEngine;
using UnityEngine.UI;


public class MoveAbilityData : ScriptableObject
{
    public delegate void moveAbilityAction(Sprite sprite, Color32 color);
    public static moveAbilityAction UpdateMoveAbilityUI;
    public float CoolDown;
    public GameObject EnginePrefab;
    public float Speed;
    public Sprite Icon;
    public Color32 Color;
    [TextArea]
    public string Description;

    public void RenderMoveAbility(Transform renderPosition)
    {
        foreach (Transform child in renderPosition)
        {
            Destroy(child.gameObject);
        }
        Instantiate(EnginePrefab, renderPosition);
    }

    public virtual void ActivateMoveAbility(Transform playerTransform, Rigidbody playerRigidbody)
    {

    }

    public void updateMovetUI()
    {
        UpdateMoveAbilityUI?.Invoke(Icon, Color);
    }

}