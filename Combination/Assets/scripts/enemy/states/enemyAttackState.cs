using System.Collections;
using UnityEngine;
using UnityEngine.AI;
public class enemyAttackState : MonoBehaviour, IStateMachine
{  
        
    private Transform _playerPosition;
    private Transform _enemyPosition;
    private float _damping;

    private float _coolDown;
    private int _shotCount;
    private float _shotTime;
    private GameObject _damager;
    private Transform _shotPoint;

    private EnemyAttack _enemyAttack;
    private bool _isCanShot = true;
    public enemyAttackState(
        Transform playerPosition, 
        Transform enemyPosition, 
        Transform shotPoint,

        float coolDown, 
        float damping, 
        int shotCount,
        float shotTime,

        GameObject damager,
        EnemyAttack enemyAttack)
    {  
        _playerPosition = playerPosition;
        _enemyPosition = enemyPosition;
        _shotPoint = shotPoint;

        _coolDown = coolDown;
        _damping = damping;
        _shotCount = shotCount;
        _shotTime = shotTime;

        _damager = damager;
        _enemyAttack = enemyAttack;
        
    }
    public void EnterState()
    {
        _isCanShot = false;
    }

    public void LoopState()
    {
        lookAtPlayer();
        _isCanShot = _enemyAttack.CanAtack();
        if(_isCanShot == true)
            _enemyAttack.Attack(_shotCount, _coolDown, _shotTime, _damager, _shotPoint);
    }

    public void ExitState()
    {
        
    }


    private void lookAtPlayer()
    {
        Vector3 lookAt = _playerPosition.position - _enemyPosition.position;

        Quaternion rotation = Quaternion.LookRotation(lookAt, Vector3.up);

        _enemyPosition.rotation = rotation;

    }
}
