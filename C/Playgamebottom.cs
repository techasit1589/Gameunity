using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Playgamebottom : MonoBehaviour
{
    public int scene;

    public void Gamestart()
    {
        SceneManager.LoadScene(scene);
    }
    
    public void Exit()
    {
        Application.Quit();
    }
    
}
