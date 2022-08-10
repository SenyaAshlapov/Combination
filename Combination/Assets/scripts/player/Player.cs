using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public delegate void playerAction();
    public static playerAction PlayerDying;
    [SerializeField]private MoveAbilityData _startMoveAbility;
    [SerializeField]private CombatAbilityData _startCombatAbility;

    private PlayerInput _playerInput;
    [SerializeField]private Transform _playerTransform;
    [HideInInspector]public Transform PlayerPosition => _playerTransform;
    [SerializeField]private Transform _shotPoint;
    [SerializeField]private Transform _moveAbilityTransform;
    [SerializeField]private Transform _combatAbilityTransform;
    private LayerMask _playerMask;
    private Vector2 _moveDirection;
    private Vector2 _mousePosition;

    [SerializeField]private float _moveSpeed;
    [SerializeField]private LayerMask _layerMask;
    private MoveAbilityData _currentMoveAbility;
    private CombatAbilityData _currentCombatAbility;

    [SerializeField]private float _health;
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
            _moveSpeed);

        initCombatAbility(_startCombatAbility);
        iniMoveAbility(_startMoveAbility);

        _playerInput.Player.shot.performed += context => castAttackAbility();
        _playerInput.Player.moveAbility.performed += context => castMoveAbility();

        PlayerSingoltone.SingoltonePlayer.SetPlayer(this);

        AbilityStore.UpdateCombatAbility += initCombatAbility;
        AbilityStore.UpdateMoveAbility += iniMoveAbility;
        AbilityStore.PlayerLockMovment += lockMove;
 
    }

    private void OnDestroy() 
    {
        AbilityStore.UpdateCombatAbility -= initCombatAbility;
        AbilityStore.UpdateMoveAbility -= iniMoveAbility;
    }


        private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void FixedUpdate() {
        if(_isCanMove == true)
        {
            _playerMove.Move();
            _playerMove.Rotate();
        }
        
    }

    #endregion

    public void GetDamage(float damage)
    {
        _health -= damage;
        if(_health <= 0){
            _isCanMove = false;
            PlayerDying?.Invoke();
        }
    }

    #region init_abilities
    private void initCombatAbility(CombatAbilityData newCombatAbility){
        newCombatAbility.RenderCombatAbility(_combatAbilityTransform);
        _currentCombatAbility = newCombatAbility;
        _currentCombatAbility.updateCombatUI();
        Debug.Log("Player");
        
    }

    private void iniMoveAbility(MoveAbilityData newMoveAbility){
        newMoveAbility.RenderMoveAbility(_moveAbilityTransform);
        _currentMoveAbility = newMoveAbility;
        _currentMoveAbility.updateMovetUI();
    }

    #endregion

    #region  abilities
    private void castAttackAbility()
    {
        if(_isCanCombatAbility == true)
            StartCoroutine(IEcombatAbility(_currentCombatAbility, _shotPoint));
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
        if(_isCanMoveAbility == true)
            StartCoroutine(IEmoveAbility(_currentMoveAbility, _playerTransform));
    }

    private IEnumerator IEmoveAbility(MoveAbilityData ability, Transform playerTransform)
    {
        _isCanMoveAbility = false;
        ability.ActivateMoveAbility(playerTransform);
        yield return new WaitForSeconds(ability.CoolDown);

        _isCanMoveAbility = true;
        yield return null;
    }

    #endregion

    private void lockMove(bool lockValue) => _isCanMove = lockValue;
    
}
    
