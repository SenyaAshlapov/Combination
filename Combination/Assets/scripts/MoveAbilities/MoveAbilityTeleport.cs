using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MoveAbilityTeleport", menuName = "Combination/MoveAbilityTeleport", order = 0)]

public class MoveAbilityTeleport : MoveAbilityData
{
    public float TeleportRange;

    public override void ActivateMoveAbility(Transform playerTransform, Rigidbody playerRigidbody)
    {
        Vector3 randomPoint = new Vector3(Random.Range(-TeleportRange, TeleportRange),0,Random.Range(-TeleportRange, TeleportRange));

        playerTransform.position += randomPoint;
        
    }
}
