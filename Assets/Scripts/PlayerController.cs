using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static int _score;
    public static bool _win;

    private Vector3 _playerMovementInput;

    [SerializeField]
    private Rigidbody _playerRigidbody;

    [SerializeField]
    private Animator _playerAnim;

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

    [SerializeField]
    private AudioSource _sfxGetFish;

    [SerializeField]
    private AudioSource _sfxHurt;

    [SerializeField]
    private AudioSource _sfxHop;

    private void Start()
    {
        _score = 0;
        _scoreText.text = _score.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        _playerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        MovePlayer();
        UpdateAnimations();
    }

    private void MovePlayer()
    {
        if(_playerMovementInput.x != 0 || _playerMovementInput.z != 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_playerMovementInput), 0.2f);
            _playerRigidbody.AddForce(transform.forward * _friction, ForceMode.Force);
            //UpdateAnimations();
        }
        transform.Translate(_playerMovementInput * _speed * Time.deltaTime, Space.World);


        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(Physics.CheckSphere(_groundCheck.position, 0.1f, _floorMask))
            {
                _sfxHop.Play();
                _playerAnim.SetBool("Jump", true);
                _playerRigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            } 
            else
            {
                _playerAnim.SetBool("Jump", false);
            }
        }
    }

    private void UpdateAnimations()
    {
        _playerAnim.SetFloat("MoveX", _playerMovementInput.x);
        _playerAnim.SetFloat("MoveY", _playerMovementInput.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Fish"))
        {
            _sfxGetFish.Play();
            _score++;
            _scoreText.text = _score.ToString();
            Destroy(other.gameObject);
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            _sfxHurt.Play();
            _win = false;
            SceneManager.LoadScene(2);
        }
    }

}
