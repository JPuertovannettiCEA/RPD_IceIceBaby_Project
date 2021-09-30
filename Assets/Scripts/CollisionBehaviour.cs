using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CollisionBehaviour : MonoBehaviour
{
    public Collider[] _currentObstacles;

    Collider[] obstaclesinsideZone;
    Collider[] obstaclesOutsideZone;

    [SerializeField]
    private LayerMask _obstacleMask;

    private bool _insideCircle;

    private void Start()
    {
        _insideCircle = false;
    }

    private void Update()
    {
        obstaclesinsideZone = Physics.OverlapSphere(this.transform.position, 4.8f, _obstacleMask);

        foreach(var obstacle in obstaclesinsideZone)
        {
            Debug.Log($"There is an obstacle inside");
            obstacle.GetComponent<Rigidbody>().velocity = 3f * obstacle.GetComponent<Rigidbody>().velocity.normalized;
            if(obstaclesinsideZone.Length >= _currentObstacles.Length)
            {
                _insideCircle = true;
            }
            //obstacle.transform.rotation = Quaternion.LookRotation(new Vector3(Random.Range(-1f,1f),0f,Random.Range(-1f,1f)));
        }

        if(_insideCircle == true)
        {
            obstaclesOutsideZone = _currentObstacles.Except(obstaclesinsideZone).ToArray();

            foreach(var obstacle in obstaclesOutsideZone)
            {
                obstacle.transform.rotation = Quaternion.LookRotation(new Vector3(Random.Range(-1f,1f),0f,Random.Range(-1f,1f)));
                //obstacle.GetComponent<Rigidbody>().velocity = 3f * obstacle.GetComponent<Rigidbody>().velocity.normalized;
                //_rb.velocity = _speed * _rb.velocity.normalized;
                //obstacle.GetComponent<Rigidbody>().AddForce(-obstacle.transform.forward * 10f, ForceMode.Force);
                //obstacle.transform.rotation = Quaternion.LookRotation(new Vector3(-obstacle.transform.forward.x,0f,-obstacle.transform.forward.z));
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, 4.8f);
    }
}
