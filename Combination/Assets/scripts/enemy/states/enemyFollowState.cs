using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyFollowState :  IStateMachine 
{
    private NavMeshAgent _navMeshAgent;
    private float _speed;
    private Player _player;

    private GameObject _moveParticle;


    public enemyFollowState(UnityEngine.AI.NavMeshAgent navMeshAgent,float speed, Player player, GameObject moveParticle){
        _navMeshAgent = navMeshAgent;
        _speed = speed;
        _player = player;

        _navMeshAgent.speed =_speed;
        _moveParticle = moveParticle;
    }
    public void EnterState()
    {
        _moveParticle.SetActive(true);
    }

    public void LoopState()
    {
        _navMeshAgent.SetDestination(_player.transform.position);
    }

    public void ExitState()
    {
        _moveParticle.SetActive(false);
    }

    
}
