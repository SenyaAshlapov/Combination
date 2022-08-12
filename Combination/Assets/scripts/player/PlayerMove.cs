using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private PlayerInput _playerInput;
    private Transform _playerTransform;
    private Rigidbody _playerRigidbody;
    private LayerMask _playerMask;
    private Vector2 _moveDirection;
    private Vector2 _mousePosition;
    private Camera _mainCamera;

    private LayerMask _layerMask;

    private float _moveSpeed;

    public void InitPlayerMove(
        PlayerInput playerInput,
        Transform playerTransform,
        Rigidbody playerRigidbody,
        LayerMask layerMask,
        float moveSpeed)
    {
        _playerInput = playerInput;
        _playerTransform = playerTransform;
        _playerRigidbody = playerRigidbody;
        _moveSpeed = moveSpeed;
        _layerMask = layerMask;

        _mainCamera = Camera.main;
    }

    public void SetSpeed(float newSpeed) => _moveSpeed = newSpeed;
    public void Move()
    {
        float moveSpeed = _moveSpeed * Time.deltaTime;
        _moveDirection = _playerInput.Player.move.ReadValue<Vector2>();

        Vector3 moveDirection = new Vector3(_moveDirection.x * moveSpeed, 0, _moveDirection.y * moveSpeed);

        _playerTransform.position += moveDirection;

    }
    public void Rotate()
    {
        _mousePosition = _playerInput.Player.mousePosition.ReadValue<Vector2>();

        Ray ray = _mainCamera.ScreenPointToRay(_mousePosition);

        RaycastHit[] rayCastHits = Physics.RaycastAll(ray, _layerMask);
        foreach (RaycastHit hit in rayCastHits)
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                lookToMouse(_playerTransform, hit);
            }
        }
    }

    private void lookToMouse(Transform player, RaycastHit mousePoint)
    {
        Vector3 direction;

        direction = mousePoint.point - player.position;
        direction.y = 0;
        player.forward = direction;
    }

    public void Teleport(float range)
    {
        Vector3 randomPoint = new Vector3(Random.Range(-range, range), 0, Random.Range(-range, range));

        _playerTransform.position += randomPoint;

    }

    public void Dash(float dashForce)
    {
        Debug.Log(dashForce);
        Debug.Log(_playerTransform == null);
        Debug.Log(_playerRigidbody == null);
        Vector3 rotationVector = _playerTransform.forward * dashForce;

        _playerRigidbody.AddForce(rotationVector, ForceMode.Impulse);
    }

    public void Acceleration(float Time, float Coeffecent)
    {
        StartCoroutine(acceleration(Time, Coeffecent));
    }

    public IEnumerator acceleration(float time, float coeffecent)
    {
        _moveSpeed *= coeffecent;

        yield return new WaitForSeconds(time);

        _moveSpeed /= coeffecent;

        yield return null;
    }
}
