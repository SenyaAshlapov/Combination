using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    #region movment_fields
    [Header("Movment")]
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private Transform _enemyPosition;
    [SerializeField] private float _speed;
    [SerializeField] private float _lookRadius;
    [SerializeField] private GameObject _moveParticle;
    #endregion
    [Space(15f)]
    #region attack_fields
    [Header("Attack")]
    [SerializeField] private GameObject _damager;
    [SerializeField] private Transform _shotPoint;
    [SerializeField] private float _health;
    [SerializeField] private float _coolDown;
    [SerializeField] private float _damping;
    [SerializeField] private int _shotCount;
    [SerializeField] private float _shotTime;
    [SerializeField] private EnemyAttack _enemyAttack;

    #endregion

    #region states
    private IStateMachine _currentState;
    private enemyIdleState _idleState;
    private enemyFollowState _followState;
    private enemyAttackState _attackState;

    #endregion

    private Player _player;
    private void Start()
    {
        setPlayer();

        _idleState = new enemyIdleState();
        _followState = new enemyFollowState(
            _navMeshAgent,
            _speed,
            _player,

            _moveParticle);

        _attackState = new enemyAttackState(
            _player.PlayerPosition,
            _enemyPosition,
            _shotPoint,

            _coolDown,
            _damping,
            _shotCount,
            _shotTime,

            _damager,
            _enemyAttack);

        _currentState = _idleState;
    }

    private void Update()
    {
        checkDistantionToPlayer();
        _currentState.LoopState();
    }
    public void GetDamage(float damage)
    {
        Debug.Log(damage);
        _health -= damage;
        if (_health <= 0)
            dyingEnemy();
    }

    private void dyingEnemy()
    {
        Destroy(this.gameObject);
    }

    private void setPlayer()
    {
        _player = PlayerSingoltone.SingoltonePlayer.GetPlayer();
    }

    private void checkDistantionToPlayer()
    {
        float distantion = Vector3.Distance(transform.position, _player.transform.position);
        if (distantion >= _lookRadius)
        {
            changeState(_idleState);
            //_currentState = _idleState;
        }

        if (distantion < _lookRadius && distantion > _navMeshAgent.stoppingDistance)
        {
            changeState(_followState);
            //_currentState = _followState;
        }
        if (distantion <= _navMeshAgent.stoppingDistance)
        {
            changeState(_attackState);
            //_currentState = _attackState;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _lookRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _navMeshAgent.stoppingDistance);

    }

    private void changeState(IStateMachine newState)
    {
        
        if(_currentState != newState)
        {
            if (_currentState != null)
                _currentState.ExitState();

            newState.EnterState();
            _currentState = newState;
        }

    }
}
