using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diolougy : MonoBehaviour
{
    public string dialogue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(DialogueSystem.Instance.interactKey))
        {
            DialogueSystem.Instance.showText(dialogue, false, "Pumpkin");
            DialogueSystem.Instance.showText("That is finished dialogue.", false);
            DialogueSystem.Instance.showText("Hello World.", true, "Story");
            //DialogueSystem.Instance.showText("This is a new world we're living in.");
            //print(dialogue);
        }
    }
}
