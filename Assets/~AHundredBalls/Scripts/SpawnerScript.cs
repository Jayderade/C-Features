using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{

    public GameObject[] prefabs = null;
    public float spawnRadius = 5f;
    public float spawnRate = 1f;
    private float spawnFactor = 0f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HandleSpawn();
    }

    void HandleSpawn()
    {
        spawnFactor += Time.deltaTime;
        if (spawnFactor > spawnRate)
        {
            int randomTimer = Random.Range(0, prefabs.Length);
            Spawn(prefabs[randomTimer]);
            spawnFactor = 0;
        }
    }

    void Spawn(GameObject _object)
    {
        GameObject newObject = Instantiate(_object);
        Vector3 randomPoint = Random.insideUnitCircle * spawnRadius;
        newObject.transform.position = transform.position + randomPoint;
    }
}
