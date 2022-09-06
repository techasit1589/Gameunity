using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cutscenemanger : MonoBehaviour
{
    public int scene;
    
    void Update()
    {
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(11);
        SceneManager.LoadScene(scene);
    }
}
