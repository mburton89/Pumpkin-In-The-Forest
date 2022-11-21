using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObject : MonoBehaviour
{
    public static DisableObject Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void disableObject()
    {
        gameObject.SetActive(false);
    }

    public void enableObject()
    {
        gameObject.SetActive(true);
    }
}
