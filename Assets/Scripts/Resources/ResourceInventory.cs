using GameJolt.API.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceInventory : MonoBehaviour
{
    [SerializeField]private int wood;
    [SerializeField] private int stone;
    [SerializeField] private int iron;

    public bool haveStructure;
    private bool inArea;
    private Resource resource;

    private void Update()
    {
        if(inArea)
        {
            RecollectResource();
        }
    }
    //void AddResourcesInBase(CentralBase centralBase)      Para cuando esten hechas las estructuras
    //{
    //    centralBase.AddWood(wood);
    //    wood = 0;
    //    centralBase.AddStone(stone);
    //    stone = 0;
    //    centralBase.AddIron(iron);
    //    iron = 0;
    //}

    void RecollectResource()
    {
        {
            if (Input.GetKeyDown(KeyCode.Space) && resource != null)
            {
                switch (resource.type)
                {
                    case Resource.ResourceType.wood:
                        wood += resource.GetAmount();
                        Destroy(resource.gameObject);
                        break;
                    case Resource.ResourceType.stone:
                        stone += resource.GetAmount();
                        Destroy(resource.gameObject);
                        break;
                    case Resource.ResourceType.iron:
                        if (haveStructure)
                        {
                            GameManager.instance.UnlockThrophies(233980);
                            iron += resource.GetAmount();
                            Destroy(resource.gameObject);
                            break;
                        }
                        else
                        {
                            Debug.Log("No se tiene la estructura necesario");
                            break;
                        }
                }
                GameManager.instance.IncreaseResourceCount();
                inArea = false;
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("CentralBase"))
        {
            //AddResourcesInBase(other.GetComponent<CentralBase>()); Para cuando esten hechas las estructuras
        }
        if (other.CompareTag("Resource"))
        {
            resource = other.GetComponent<Resource>();
            inArea = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Resource"))
        {
            resource = null;
            inArea = false;
        }
    }
}
