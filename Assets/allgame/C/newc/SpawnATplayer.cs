using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class SpawnATplayer : MonoBehaviour
{
    public GameObject objectToSpawn;

    public float timeToSpawn;

    private float currentTimeToSpawn;

    // Update is called once per frame
    void Update()
    {
        if (currentTimeToSpawn > 0)
        {
            currentTimeToSpawn -= Time.deltaTime;
        }
        else
        {
            Spawnject();
            currentTimeToSpawn = timeToSpawn;
        }
    }

    public void Spawnject()
    {
        Instantiate(objectToSpawn, transform.position, transform.rotation);
    }
}
