using System;
using UnityEngine;

public class Tester_PlayerController : MonoBehaviour
{

    [SerializeField]
    private float _moveSpeed;
    [SerializeField]
    private float _jumpSpeed;
    [SerializeField]
    private Animator _playerAnim;

    private Rigidbody _rigidBody;
    private float _zInput;
    private float _xInput;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ReadInputs();
        UpdateAnimations();
    }

    private void UpdateAnimations()
    {
        //tell anim controller to update MoveX parameters
        _playerAnim.SetFloat("MoveX", _xInput);
        _playerAnim.SetFloat("MoveY", _zInput);
    }

    private void ReadInputs()
    {
        _zInput = Input.GetAxis("Vertical");
        _xInput = Input.GetAxis("Horizontal");
        //Vector3 direction = new Vector3(_xInput, 0f, _zInput).normalized;

        var newMoveVelocity = transform.forward * _zInput + transform.right * _xInput;
        newMoveVelocity = newMoveVelocity.normalized * _moveSpeed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            newMoveVelocity.y = _jumpSpeed;
        }
        else
        {
            newMoveVelocity.y = _rigidBody.velocity.y;
        }

        _rigidBody.velocity = newMoveVelocity;

    }
}
