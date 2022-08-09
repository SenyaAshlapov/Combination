using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
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
    private CombatAbilityData _currntCombatAbility;



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
        _playerMove.Move();
        _playerMove.Rotate();
    }

    #endregion

    #region init_abilities
    private void initCombatAbility(CombatAbilityData newCombatAbility){
        newCombatAbility.RenderCombatAbility(_combatAbilityTransform);
        _currntCombatAbility = newCombatAbility;
    }

    private void iniMoveAbility(MoveAbilityData newMoveAbility){
        newMoveAbility.RenderMoveAbility(_moveAbilityTransform);
        _currentMoveAbility = newMoveAbility;
    }

    #endregion

    private void castAttackAbility()
    {
        if(_isCanCombatAbility == true)
            StartCoroutine(IEcombatAbility(_currntCombatAbility, _shotPoint));
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
}
