using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _lifeSpan = 5f;

    [SerializeField]
    private Rigidbody _rb;

    [SerializeField]
    private Transform _groundCheck;

    [SerializeField]
    private LayerMask _floorMask;

    private bool _isGround;


    private void Awake()
    {
        //_isGround = false;
        Destroy(gameObject, _lifeSpan);
    }

    private void Update()
    {
        //transform.Rotate(0f,1f,0f, Space.Self);
        if(Physics.CheckSphere(_groundCheck.position, 0.2f, _floorMask))
        {
            _rb.isKinematic = true;
        }
    }

}
