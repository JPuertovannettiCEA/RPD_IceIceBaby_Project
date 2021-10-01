using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    //[SerializeField]
    private Vector3 _spawnOffset;

    [SerializeField]
    private GameObject _obstacle;

    [SerializeField]
    private GameObject _fish;

    private float counter = 0f;
    private bool _fishOn = false;

    private void Update()
    {
        counter += Time.deltaTime;
        _spawnOffset = new Vector3(Random.Range(-1f,1f), 0f, Random.Range(-1f,1f));
        if(counter >= 5f && _fishOn == false) //Fish 
        {
            SpawnObjects(_fish);
            _fishOn = true;
        }
        if (counter >= 10f) //Spikey Cubes
        {
            SpawnObjects(_obstacle);
            counter = 0f;
            _fishOn = false;
        }
    }

    public void SpawnObjects(GameObject prefab)
    {
        if(prefab == _fish)
        {
            Instantiate(prefab, transform.position + _spawnOffset, Quaternion.identity);
        }
        else
        {
            Instantiate(prefab, transform.position + _spawnOffset, transform.rotation);
        }
    }

}
