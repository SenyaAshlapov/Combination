using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MoveAbilityDash", menuName = "Combination/MoveAbilityDash", order = 0)]

public class MoveAbilityDash : MoveAbilityData
{
    public float DashForce;
    public override void ActivateMoveAbility(PlayerMove playerMove)
    {
        playerMove.Dash(DashForce);
    }
}
