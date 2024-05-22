using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameJolt.API;
using GameJolt.UI;
public class Board : MonoBehaviour
{
    void Start()
    {
        GameJoltUI.Instance.ShowTrophies();
    }
}
