using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnAt : MonoBehaviour
{
    public GameObject pre;

    public GameObject[] pos;

    void Start()
    {
        int rand = Random.Range(0, pos.Length);

        pos[rand] = Instantiate(pre, pos[rand].transform.position, Quaternion.identity);
    }

}
