using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rb;

    [SerializeField]
    private float _speed;

    //[SerializeField]
    //private float _acceleration;

    [SerializeField]
    private Transform _groundCheck;

    [SerializeField]
    private LayerMask _floorMask;

    //[SerializeField]
    //private float _friction;

    private bool _isGround;

    private void Start()
    {
        _isGround = false;
    }

    private void Update()
    {
        if(Physics.CheckSphere(_groundCheck.position, 0.1f, _floorMask) && _isGround == false)
        {
            _rb.velocity = transform.forward * _speed;
            _rb.velocity = _speed * _rb.velocity.normalized;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Collider") || other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log($"COLLISION");
            Vector3 dir = other.contacts[0].point - transform.position;
            dir = -dir.normalized;
            transform.rotation = Quaternion.LookRotation(new Vector3(dir.x,0f,dir.z));
        }
        
    }
}
