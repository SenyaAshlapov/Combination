using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private PlayerInput _playerInput;
    private Transform _playerTransform;
    private LayerMask _playerMask;
    private Vector2 _moveDirection;
    private Vector2 _mousePosition;
    private Camera _mainCamera;

    private LayerMask _layerMask;

    private float _moveSpeed;

    public void InitPlayerMove(
        PlayerInput playerInput,
        Transform playerTransform,
        LayerMask layerMask,
        float moveSpeed)
    {
        _playerInput = playerInput;
        _playerTransform = playerTransform;
        _moveSpeed = moveSpeed;
        _layerMask = layerMask;

        _mainCamera = Camera.main;
    }
    public void Move()
    {
        float moveSpeed = _moveSpeed * Time.deltaTime;
        _moveDirection = _playerInput.Player.move.ReadValue<Vector2>();

        Vector3 moveDirection = new Vector3(_moveDirection.x * moveSpeed , 0 , _moveDirection.y * moveSpeed) ;

        //_playerTransform.Translate(moveDirection * moveSpeed);
        _playerTransform.position += moveDirection;

    }
    public void Rotate()
    {
        _mousePosition = _playerInput.Player.mousePosition.ReadValue<Vector2>();

        Ray ray = _mainCamera.ScreenPointToRay(_mousePosition);

        RaycastHit[] rayCastHits = Physics.RaycastAll(ray, _layerMask);
            foreach(RaycastHit hit in rayCastHits)
            {
                if(hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
                {
                    lookToMouse(_playerTransform, hit);
                }
            }
    }

    private void lookToMouse(Transform player,RaycastHit mousePoint)
    {
        Vector3 direction;

        direction = mousePoint.point - player.position;
        direction.y = 0;
        player.forward = direction;
    }
}
