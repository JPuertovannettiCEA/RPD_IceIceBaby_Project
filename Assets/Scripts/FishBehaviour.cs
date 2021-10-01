using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBehaviour : MonoBehaviour
{
    [SerializeField]
    private float _lifeSpan = 5f;

    private void Awake()
    {
        Destroy(gameObject, _lifeSpan);
    }

    private void Update()
    {
        transform.Rotate(0f,1f,0f, Space.Self);
    }

}
