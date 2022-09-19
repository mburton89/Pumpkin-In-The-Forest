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
        if (Input.GetKeyDown(KeyCode.A))
        {
            DialogueSystem.Instance.showText(dialogue);
            print(dialogue);
        }
    }
}
