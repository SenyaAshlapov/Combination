using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public delegate void playerAction();
    public delegate void playerFloatAction(float value);
    public static playerAction PlayerDying;
    public static playerFloatAction UpdateHealthBar;
    [SerializeField] private MoveAbilityData _startMoveAbility;
    [SerializeField] private CombatAbilityData _startCombatAbility;

    private PlayerInput _playerInput;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Rigidbody _playerRigidbody;
    [HideInInspector] public Transform PlayerPosition => _playerTransform;
    [SerializeField] private Transform _shotPoint;
    [SerializeField] private Transform _moveAbilityTransform;
    [SerializeField] private Transform _combatAbilityTransform;
    private LayerMask _playerMask;
    private Vector2 _moveDirection;
    private Vector2 _mousePosition;

    [SerializeField] private LayerMask _layerMask;
    private MoveAbilityData _currentMoveAbility;
    private CombatAbilityData _currentCombatAbility;


    [SerializeField] private Animator _playerAniator;
    [SerializeField] private float _health;
    private bool _isCanMove = true;



    private PlayerMove _playerMove = new PlayerMove();

    private bool _isCanCombatAbility = true;
    private bool _isCanMoveAbility = true;

    #region  unity_functions
    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerMove.InitPlayerMove(
            _playerInput,
            _playerTransform,
            _layerMask,
            0);

        initCombatAbility(_startCombatAbility);
        iniMoveAbility(_startMoveAbility);

        _playerInput.Player.shot.performed += context => castAttackAbility();
        _playerInput.Player.moveAbility.performed += context => castMoveAbility();

        PlayerSingoltone.SingoltonePlayer.SetPlayer(this);

        AbilityStore.UpdateCombatAbility += initCombatAbility;
        AbilityStore.UpdateMoveAbility += iniMoveAbility;

        AbilityStore.PlayerLockMovment += lockMove;
        GameMenu.PlayerLockMovment += lockMove;

    }

    private void OnDestroy()
    {
        AbilityStore.UpdateCombatAbility -= initCombatAbility;
        AbilityStore.UpdateMoveAbility -= iniMoveAbility;

        AbilityStore.PlayerLockMovment -= lockMove;
        GameMenu.PlayerLockMovment -= lockMove;
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
        if(_isCanMove == true)
        {
            _health -= damage;
            UpdateHealthBar(_health);
        
            if (_health <= 0)
            {
            _isCanMove = false;
            PlayerDying?.Invoke();
            }
        }
        
    }

    #region init_abilities
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
            StartCoroutine(IEcombatAbility(_currentCombatAbility, _shotPoint));
        _playerAniator.Play("Base Layer.Impact", 0, 0.25f);
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
        if (_isCanMoveAbility == true && _isCanMove == true)
            StartCoroutine(IEmoveAbility(_currentMoveAbility, _playerTransform, _playerRigidbody));
    }

    private IEnumerator IEmoveAbility(MoveAbilityData ability, Transform playerTransform, Rigidbody playerRigidbody)
    {
        _isCanMoveAbility = false;
        ability.ActivateMoveAbility(playerTransform, playerRigidbody);
        yield return new WaitForSeconds(ability.CoolDown);

        _isCanMoveAbility = true;
        yield return null;
    }

    #endregion

    private void lockMove(bool lockValue) => _isCanMove = lockValue;

}

