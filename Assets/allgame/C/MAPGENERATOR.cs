using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAPGENERATOR : MonoBehaviour
{
    public GameObject[] objects;
    private GameObject s1Button;

    public GameObject ChoiceButtonHolder;

    void Start()
    {
        int rand = Random.Range(0, objects.Length);
        s1Button = Instantiate(objects[rand],transform.position,Quaternion.identity);
        //s1Button.transform.SetParent(ChoiceButtonHolder.transform);
    }

}
