using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public static int _score;

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

    [SerializeField]
    private float _friction;

    [SerializeField]
    private TMP_Text _scoreText;


    private void Start()
    {
        _score = 0;
        _scoreText.text = "Score: " + _score.ToString();
    }
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
            _playerRigidbody.AddForce(transform.forward * _friction, ForceMode.Force);
        }
        transform.Translate(_playerMovementInput * _speed * Time.deltaTime, Space.World);


        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(Physics.CheckSphere(_groundCheck.position, 0.1f, _floorMask))
            {
                _playerRigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Fish"))
        {
            _score++;
            _scoreText.text = "Score: " + _score.ToString();
            Destroy(other.gameObject);
        }
    }

}
