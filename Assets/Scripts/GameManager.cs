using GameJolt.API;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int resourceCount;
    private Action<int> OnResourceCountChanged = (int value) => { };

    void Start()
    {
        instance = this;
    }

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

    public void UnlockTrophies(int id)
    {
        Trophies.TryUnlock(id);
    }
}
