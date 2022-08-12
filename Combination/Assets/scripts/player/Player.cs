using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public delegate void playerAction();
    public delegate void playerFloatAction(float value);
    public static playerAction PlayerDying;
    public static playerFloatAction UpdateHealthBar;

    [Header("Movment")]
    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Rigidbody _playerRigidbody;
    [HideInInspector] public Transform PlayerPosition => _playerTransform;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Transform _moveAbilityTransform;

    private LayerMask _playerMask;
    private bool _isCanMove = true;

    private Vector2 _moveDirection;
    private Vector2 _mousePosition;

    private MoveAbilityData _currentMoveAbility;
    [SerializeField] private MoveAbilityData _startMoveAbility;
    private bool _isCanMoveAbility = true;

    private PlayerInput _playerInput;


    [Space(10)]

    [Header("Combat")]
    [SerializeField] private Transform _shotPoint;
    [SerializeField] private Transform _combatAbilityTransform;
    private CombatAbilityData _currentCombatAbility;
    [SerializeField] private CombatAbilityData _startCombatAbility;
    [SerializeField] private float _health;
    private bool _isCanCombatAbility = true;



    [Space(10)]

    [Header("Effectst")]

    [SerializeField] private Animator _playerAniator;
    [SerializeField] private AudioSource _shotSound;
    [SerializeField] private AudioSource _deadSound;

    [Space(10)]

    private HealthData _currentHealth;

    #region  unity_functions
    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerMove.InitPlayerMove(
            _playerInput,
            _playerTransform,
            _playerRigidbody,
            _layerMask,
            0);

        initCombatAbility(_startCombatAbility);
        iniMoveAbility(_startMoveAbility);

        _playerInput.Player.shot.performed += context => castAttackAbility();
        _playerInput.Player.moveAbility.performed += context => castMoveAbility();
        _playerInput.Player.health.performed += context => UseHealth();

        PlayerSingoltone.SingoltonePlayer.SetPlayer(this);

        AbilityStore.UpdateCombatAbility += initCombatAbility;
        AbilityStore.UpdateMoveAbility += iniMoveAbility;

        AbilityStore.PlayerLockMovment += lockMove;
        GameMenu.PlayerLockMovment += lockMove;
        WaveSpawner.GameComplete += levelComplete;


    }

    private void OnDestroy()
    {
        AbilityStore.UpdateCombatAbility -= initCombatAbility;
        AbilityStore.UpdateMoveAbility -= iniMoveAbility;

        AbilityStore.PlayerLockMovment -= lockMove;
        GameMenu.PlayerLockMovment -= lockMove;
        WaveSpawner.GameComplete -= levelComplete;
    }


    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void FixedUpdate()
    {
        if (_isCanMove == true)
        {
            _playerMove.Move();
            _playerMove.Rotate();
        }

    }

    #endregion

    public void GetDamage(float damage)
    {
        if (_isCanMove == true)
        {
            _health -= damage;
            UpdateHealthBar(_health);

            if (_health <= 0)
            {
                _deadSound.Play();
                _isCanMove = false;
                PlayerDying?.Invoke();
            }
        }
    }

    public void UseHealth()
    {
        if(_currentHealth != null){
            _health += _currentHealth.UseHealth();
            UpdateHealthBar(_health);
            if(_health > 100) _health = 100;

            _currentHealth = null;
        }

    }

    #region init_abilities

    public void InitHealth(HealthData newHealth){
        _currentHealth = newHealth;
        _currentHealth.InitHealth();
    }
    private void initCombatAbility(CombatAbilityData newCombatAbility)
    {
        newCombatAbility.RenderCombatAbility(_combatAbilityTransform);
        _currentCombatAbility = newCombatAbility;
        _currentCombatAbility.updateCombatUI();

    }

    private void iniMoveAbility(MoveAbilityData newMoveAbility)
    {
        newMoveAbility.RenderMoveAbility(_moveAbilityTransform);
        _currentMoveAbility = newMoveAbility;
        _currentMoveAbility.updateMovetUI();
        _playerMove.SetSpeed(newMoveAbility.Speed);
    }

    #endregion

    #region  abilities
    private void castAttackAbility()
    {
        if (_isCanCombatAbility == true && _isCanMove == true)
        {
            _shotSound.Play();
            StartCoroutine(IEcombatAbility(_currentCombatAbility, _shotPoint));
            _playerAniator.Play("Base Layer.Impact", 0, 0.25f);
        }

    }

    private IEnumerator IEcombatAbility(CombatAbilityData ability, Transform shotPoint)
    {
        _isCanCombatAbility = false;
        ability.ActivateCombatAbility(shotPoint);
        yield return new WaitForSeconds(ability.CoolDown);

        _isCanCombatAbility = true;
        yield return null;
    }

    private void castMoveAbility()
    {
        if (_isCanMoveAbility == true)
        {
            StartCoroutine(IEmoveAbility(_currentMoveAbility, _playerTransform, _playerRigidbody));
        }

    }

    private IEnumerator IEmoveAbility(MoveAbilityData ability, Transform playerTransform, Rigidbody playerRigidbody)
    {
        _isCanMoveAbility = false;
        ability.ActivateMoveAbility(_playerMove);
        yield return new WaitForSeconds(ability.CoolDown);

        _isCanMoveAbility = true;
        yield return null;
    }

    #endregion

    private void levelComplete(){
        _isCanMove = false;
    }

    private void lockMove(bool lockValue) => _isCanMove = lockValue;

}

