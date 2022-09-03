using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiGame : MonoBehaviour
{
    public int scene;
    public GameObject PauseUi;
    public void Exit()
    {
        Application.Quit();
    }
    public void Gamestart()
    {
        SceneManager.LoadScene(scene);
    }
    public void Reset()
    {
        SceneManager.LoadScene(scene);
        Time.timeScale = 1;
        PauseUi.SetActive(false);
    }
}
