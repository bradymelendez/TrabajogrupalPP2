using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevels : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadScene1()
    {
        SceneManager.LoadScene("Win");
    }
    public void LoadScene2()
    {
        SceneManager.LoadScene("Lose");
    }
    public void LoadScene3()
    {
        SceneManager.LoadScene("Credits");
    }
    public void LoadScene4()
    {
        SceneManager.LoadScene("Level");
    }
}
