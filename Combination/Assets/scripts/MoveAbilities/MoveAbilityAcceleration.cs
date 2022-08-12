using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MoveAbilityAcceleration", menuName = "Combination/MoveAbilityAcceleration", order = 0)]
public class MoveAbilityAcceleration : MoveAbilityData
{
    public float SpeedCoeffecent;
    public float TimeAcceleration;

    public override void ActivateMoveAbility(PlayerMove playerMove)
    {
        playerMove.Acceleration(TimeAcceleration, SpeedCoeffecent);
        
    }
}
