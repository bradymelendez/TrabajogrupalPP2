using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceInventory : MonoBehaviour
{
    public int wood;
    public int stone;
    public int iron;
        
    private bool inArea;
    private Resource resource;
    private bool haveStructure;

    private void Update()
    {
        if (inArea && Input.GetKeyDown(KeyCode.Space) && resource != null)
        {
            switch (resource.type)
            {
                case Resource.ResourceType.Wood:
                    wood += resource.GetAmount();
                    Destroy(resource.gameObject);
                    break;
                case Resource.ResourceType.Stone:
                    stone += resource.GetAmount();
                    Destroy(resource.gameObject);
                    break;
                case Resource.ResourceType.Iron:
                    if (haveStructure)
                    {
                        GameManager.instance.UnlockTrophies(233980);
                        iron += resource.GetAmount();
                        Destroy(resource.gameObject); 
                    }
                    else
                    {
                        Debug.Log("No se tiene la estructura necesaria");
                    }
                    break;
            }
            GameManager.instance.IncreaseResourceCount();
            inArea = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
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
            inArea = false;
        }
    }
       
    public void SetHasStructure(bool value)
    {
        haveStructure = value;
    }
}
