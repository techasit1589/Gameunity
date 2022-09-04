using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keydoor : MonoBehaviour
{

    [SerializeField] private Key.KeyType keyType;

    public float speed;
    public Transform[] points;
    private int i = 0;

    void Update()
    {
        if (i == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[0].position, speed * Time.deltaTime);
        }
    }
    public Key.KeyType GetKeyType()
    {
        return keyType;
    }
    public void OpenDoor()
    {
        //gameObject.SetActive(false);
        i = 1;
    }
}
