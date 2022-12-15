using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Transform orientation;
    private CharacterController _controller;
    private Animator mAnimator;
    private bool jumping;
    
    [SerializeField]
    private float _playerSpeed = 5f;

    [SerializeField]
    private float _rotationSpeed = 10f;

    [SerializeField]
    private Camera _followCamera;

    private Vector3 _playerVelocity;
    private bool _groundedPlayer;
    private float _dashWait = 5f;
    private float _dashTime = 0.225f;
    private float _dashForce = 1.75f;

    [SerializeField]
    private float _jumpHeight = 1.0f;
    [SerializeField]
    private float _gravityValue = -9.81f;

    void Start()
    {
        orientation = gameObject.GetComponent<Transform>();
        _controller = GetComponent<CharacterController>();
        mAnimator = GetComponent<Animator>();
        jumping = false;
    }

    // Update is called once per frame
    void Update()
    {

        Movement();
    }
    void Movement()
    {
        _dashWait += Time.deltaTime;
        if (_dashWait <= 5f)
        {
            TrackTimeLimit.DashTime = _dashWait;
        }
        else
        {
            TrackTimeLimit.DashTime = 5f;
        }
        _groundedPlayer = _controller.isGrounded;

        if(jumping && _groundedPlayer)
        {
            jumping = false;
        }

        if (_groundedPlayer && _playerVelocity.y < 0)
        {
            _playerVelocity.y = 0f;
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementInput = Quaternion.Euler(0, _followCamera.transform.eulerAngles.y, 0) * new Vector3(horizontalInput, 0, verticalInput);
        Vector3 movementDirection = movementInput.normalized;

        _controller.Move(movementDirection * _playerSpeed * Time.deltaTime);

        if (movementDirection != Vector3.zero)
        {
            Quaternion desiredRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, _rotationSpeed * Time.deltaTime);
        }

        if(movementDirection != Vector3.zero && mAnimator != null && !jumping)
        {
            mAnimator.SetTrigger("TWalk");
        } else
        {
            mAnimator.SetTrigger("TIdle");
        }

        if (Input.GetButtonDown("Jump") && !jumping)
        {
            _playerVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravityValue);
            jumping = true;
        }

        if (Input.GetKey(KeyCode.Mouse1) && _dashWait >= 5 && !jumping)
        {
            _dashWait = 0f;
            StartCoroutine(Dash());
        }

        _playerVelocity.y += _gravityValue * Time.deltaTime;
        _controller.Move(_playerVelocity * Time.deltaTime);
    }

    IEnumerator Dash()
    {
        float startTime = Time.time;
        Vector3 forceToApply = orientation.forward * _dashForce;

        while (Time.time < startTime + _dashTime)
        {
            _controller.Move(forceToApply);

            yield return null;
        }
    }
}
