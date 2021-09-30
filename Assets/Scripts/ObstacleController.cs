using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rb;

    private void Update()
    {
        _rb.AddTorque(transform.forward * 2f, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log($"COLLISION");
        _rb.AddTorque(transform.forward * 5f, ForceMode.VelocityChange);
    }
}
