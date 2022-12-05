using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObjectsManager : MonoBehaviour
{
    public static DisableObjectsManager Instance;

    public static List<DisableObject> objectsToDsiable;
    private void Awake()
    {
        Instance = this;
    }

    public void AddObject(DisableObject ObjectToAdd)
    {
        objectsToDsiable.Add(ObjectToAdd);
    }

    public void RemoveObject(DisableObject ObjectToRemove)
    {
        objectsToDsiable.Remove(ObjectToRemove);
    }

    public void disableObjects()
    {
        /*
        foreach (DisableObject obj in objectsToDsiable)
        {
            obj.gameObject.SetActive(false);
        }*/
    }

    public void enableObjects()
    {
        /*
        foreach (DisableObject obj in objectsToDsiable)
        {
            obj.gameObject.SetActive(true);
        }*/
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
