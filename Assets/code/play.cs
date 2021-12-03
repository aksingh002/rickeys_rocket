using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class play : MonoBehaviour
{
    public void playgame()
    {
        SceneManager.LoadScene(1);
    }
    public void quidgame()
    {
        Application.Quit();
    }
}
