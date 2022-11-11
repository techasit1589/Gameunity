using UnityEngine;
using UnityEngine.SceneManagement;

public class skipcutscenes : MonoBehaviour
{
    public int scene=5;
    
    public void skipcut()
    {
        SceneManager.LoadScene(scene);
    }
}
