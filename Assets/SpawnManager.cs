using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] GameObject manaObj;

    [SerializeField] float spawnDelay = 1f;

    [SerializeField] Transform spawnMin;
    [SerializeField] Transform spawnMax;
    float spawnTimer = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > spawnDelay)
        {
            spawnTimer = 0;
            SpawnMana();
        }

    }

    // spawn at random positionn onn the x axis
    public void SpawnMana()
    {
        Vector3 spawnPos = new Vector3(Random.Range(spawnMin.position.x, spawnMax.position.x), transform.position.y, 0);
        Instantiate(manaObj, spawnPos, Quaternion.identity);
    }


}
