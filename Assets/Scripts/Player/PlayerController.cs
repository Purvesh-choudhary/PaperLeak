using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float rotationSpeed = 10f; // Speed of rotation transition
    
    private CharacterController _controller;
    private Vector3 _velocity;
    private Vector2 _moveInput;
    private bool _isGrounded;
    
    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }
    
    private void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleGravity();
    }
    
    public void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }
    
    public void OnJump(InputValue value)
    {
        if (_isGrounded && value.isPressed)
        {
            _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
    
    private void HandleMovement()
    {
        _isGrounded = _controller.isGrounded;
        Vector3 move = new Vector3(_moveInput.x, 0, _moveInput.y);
        _controller.Move(move * moveSpeed * Time.deltaTime);
    }
    
    private void HandleRotation()
    {
        if (_moveInput.magnitude > 0.1f)
        {
            Vector3 moveDirection = new Vector3(_moveInput.x, 0, _moveInput.y);
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
    
    private void HandleGravity()
    {
        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }
        _velocity.y += gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
    }
}