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
    private float counterFish = 0f;
    private bool _fishOn = false;

    private void Update()
    {
        counter += Time.deltaTime;
        counterFish += Time.deltaTime;
        _spawnOffset = new Vector3(Random.Range(-5f,5f), 0f, Random.Range(-5f,5f));
        if(counterFish >= 2f) //Fish
        {
            SpawnObjects(_fish);
            counterFish = 0f;
        }
        if (counter >= 10f) //Spikey Cubes
        {
            SpawnObjects(_obstacle);
            counter = 0f;
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
