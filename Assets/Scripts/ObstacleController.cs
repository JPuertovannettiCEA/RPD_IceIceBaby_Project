using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rb;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _acceleration;

    [SerializeField]
    private Transform _groundCheck;

    [SerializeField]
    private LayerMask _floorMask;

    [SerializeField]
    private float _friction;

    private bool _isGround;

    private void Start()
    {
        _isGround = false;
        //_rb.velocity = transform.forward * _speed;
    }

    private void Update()
    {
        if(Physics.CheckSphere(_groundCheck.position, 0.1f, _floorMask) && _isGround == false)
        {
            //_speed += _acceleration;
            _rb.velocity = transform.forward * _speed;
            _rb.velocity = _speed * _rb.velocity.normalized;
            //_isGround = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Collider") || other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log($"COLLISION");
            //transform.forward = new Vector3(Random.Range(-1,1), 0f, 0f);
            Vector3 dir = other.contacts[0].point - transform.position;
            dir = -dir.normalized;
            transform.rotation = Quaternion.LookRotation(new Vector3(dir.x,0f,dir.z));
            //_rb.velocity = dir * _speed;
            //_rb.velocity = _speed * _rb.velocity.normalized;
            //_speed += _acceleration;
            //_rb.velocity = new Vector3(Random.Range(-5f,5f), 0f, 0f) * _speed;
            //_rb.velocity = -transform.forward * _speed;
        }
        
    }
}
