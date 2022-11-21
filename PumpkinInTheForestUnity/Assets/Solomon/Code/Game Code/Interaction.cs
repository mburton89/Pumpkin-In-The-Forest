using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public bool displayOnMe = true;
    public bool useDefaultIcon = true;

    public Sprite myInteractionIcon = null;

    void Start()
    {
        
    }

    public bool GetDisplayOnMe()
    {
        return displayOnMe;
    }

    public bool GetUseDefaultIcon()
    {
        return useDefaultIcon;
    }

    public Sprite GetObjectIcon()
    {
        return myInteractionIcon;
    }
}
