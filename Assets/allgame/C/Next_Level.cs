using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next_Level : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject box2;
    public int scene;
    void OnTriggerEnter2D(Collider2D next)
    {
        if (next.gameObject.tag == "Player")
        {
            Debug.Log("ด่านต่อไป");
            StartCoroutine(NextLevel());
        }
    }
    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene);
    }
}
