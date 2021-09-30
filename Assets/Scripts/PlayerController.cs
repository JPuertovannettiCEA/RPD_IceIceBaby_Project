using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 _playerMovementInput;

    [SerializeField]
    private Rigidbody _playerRigidbody;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _jumpForce;

    [SerializeField]
    private Transform _groundCheck;

    [SerializeField]
    private LayerMask _floorMask;

    // Update is called once per frame
    void Update()
    {
        _playerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        MovePlayer();
    }

    private void MovePlayer()
    {
        if(_playerMovementInput.x != 0 || _playerMovementInput.z != 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_playerMovementInput), 0.2f);
        }
        transform.Translate(_playerMovementInput * _speed * Time.deltaTime, Space.World);
        //if(_playerMovementInput == Vector3.zero)
        //{
        //    _playerRigidbody.AddForce(10f,0f,0f, ForceMode.Force);
        //}


        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(Physics.CheckSphere(_groundCheck.position, 0.1f, _floorMask))
            {
                _playerRigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            }
        }
    }

}
