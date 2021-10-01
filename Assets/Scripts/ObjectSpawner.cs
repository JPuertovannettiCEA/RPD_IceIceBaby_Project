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

    private float _timeBetweenSpawns = 1f;
    private float _timeNextSpawn;
    
    private void Start()
    {
        _timeNextSpawn = Timer.timer - _timeBetweenSpawns;
    }

    private void Update()
    {
        _spawnOffset = new Vector3(Random.Range(-10f,10f), 0f, Random.Range(-10f,10f));
        //This condition is to indicate when there will be a spawn happening
        if (_timeNextSpawn > Timer.timer) //Spawn Condition
        {
            SpawnObjects(_obstacle);
            _timeNextSpawn = Timer.timer - _timeBetweenSpawns;
            //Debug.Log("Somethin happens here");
            //Instantiate(objectwhatever, position, Quaternion.identity);
        }
    }

    public void SpawnObjects(GameObject prefab)
    {
        Instantiate(prefab, transform.position + _spawnOffset, transform.rotation);
        //_timeBetweenSpawns = 10f;
    }

}
