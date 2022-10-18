using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cutscenemanger : MonoBehaviour
{
    public int scene;
    public float timescene;
    
    void Update()
    {
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(timescene);
        SceneManager.LoadScene(scene);
    }
}
