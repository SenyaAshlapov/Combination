using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerInput _playerInput;
    [SerializeField]private Transform _playerTransform;
    private LayerMask _playerMask;
    private Vector2 _moveDirection;
    private Vector2 _mousePosition;

    [SerializeField]private float _moveSpeed;
    [SerializeField]private LayerMask _layerMask;

    [SerializeField]private MoveAbilityData _moveAbility;

    private PlayerMove _playerMove = new PlayerMove();
    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerMove.InitPlayerMove(
            _playerInput,
            _playerTransform,
            _layerMask,
            _moveSpeed);
 
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
}
