using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MoveAbilityTeleport", menuName = "Combination/MoveAbilityTeleport", order = 0)]

public class MoveAbilityTeleport : MoveAbilityData
{
    public float TeleportRange;

    public override void ActivateMoveAbility(PlayerMove playerMove)
    {
        playerMove.Teleport(TeleportRange);
        
    }
}
