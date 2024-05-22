using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameJolt.API;
using GameJolt.UI;
using UnityEngine.SceneManagement;

public class LevelLoad: MonoBehaviour
{
    void Start()
    {
        GameJoltUI.Instance.ShowSignIn((bool isSignedIn) =>
        {
            if (isSignedIn)
            {
                UnLockTrophy();
                SceneManager.LoadScene("Level");
            }
            else
            {
                Debug.Log("error");
            }
        });
    }
    void UnLockTrophy()
    {
        Trophies.TryUnlock(233715);
    }
}
