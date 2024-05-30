using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameJolt.API;
using GameJolt.UI;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    void Start()
    {
        Trophies.TryUnlock(233716);
    }
    public void LoadScene2()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
