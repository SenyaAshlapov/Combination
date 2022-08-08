using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MOveAbilityData", menuName = "Combination/MOveAbility1", order = 0)]

public class MoveAbility1 : MoveAbilityData
{
    public override void ActivateMoveAbility(Transform playerTransform)
    {
        Debug.Log("moveAbility");
    }
}
