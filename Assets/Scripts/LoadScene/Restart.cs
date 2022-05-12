using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Restart : MonoBehaviour
{
    public int scene;
    public void RestartGame()
    {
        SceneManager.LoadScene(scene); // loads current scene
    }

}
