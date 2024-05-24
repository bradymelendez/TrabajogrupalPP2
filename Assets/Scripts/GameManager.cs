using GameJolt.API;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int resourceCount;
    private Action<int> OnResourceCountChanged = (int value) => { };
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        UnLockTrophiesbyResourceCount();
    }

    public void SetOnEnemyCountChanged(Action<int> action)
    {
        OnResourceCountChanged = action;
    }

    public void IncreaseResourceCount()
    {
        resourceCount++;
        OnResourceCountChanged?.Invoke(resourceCount);
    }

    void UnLockTrophiesbyResourceCount()
    {
        switch (resourceCount)
        {
            case 1:
                Trophies.TryUnlock(233979);
                break;
        }
    }
    public void UnlockThrophies(int id)
    {
        Trophies.TryUnlock(id);
    }
}
