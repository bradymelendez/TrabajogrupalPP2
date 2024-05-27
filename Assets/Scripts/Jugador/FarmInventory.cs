using GameJolt.API;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmInventory : MonoBehaviour
{
    public int animals;
    public int plants;

    public GameObject prefabAnimal;
    public GameObject prefabPlants;

    void PlacePlant(/*Farm farm*/)
    {
        if (plants > 0)
        {
            plants--;
            //farm.AddPlant();
            //Instantiate(prefabPlants, farm.gameobject.transform.position);
            Trophies.TryUnlock(234218);
        }

    }

    void PlaceAnimal(/*Farm farm*/)
    {
        if (animals > 0)
        {
            animals--;
            //farm.AddAnimal();
            //Instantiate(prefabAnimal, farm.gameobject.transform.position);
            Trophies.TryUnlock(234219);
        }
    }
}
