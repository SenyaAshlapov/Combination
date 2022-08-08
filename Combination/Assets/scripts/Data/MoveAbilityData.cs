using UnityEngine;
using UnityEngine.UI;


public class MoveAbilityData : ScriptableObject 
{
    public float CoolDown;
    public GameObject EnginePrefab;
    public MoveAbility Ability;
    public float Speed;
    public Sprite Icon;
    public Color32 Color;
    [TextArea]
    public string Description;

    public void RenderMoveAbility(Transform renderPosition){
        foreach(Transform child in renderPosition){
            Destroy(child.gameObject);
        }
        Instantiate(EnginePrefab, renderPosition);
    }

    public virtual void Activate(){

    }

}