using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScene : MonoBehaviour
{
    public Dictionary<int, string> conversations;
    public int defaultIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        //print("Entered collision");
        if (collision.gameObject.GetComponent<CharacterController>())
        {
            print("Entered collision with freind.");
            if (Input.GetKeyDown(DialogueSystem.Instance.interactKey))
            {
                DialogueSystem.Instance.showText("Hello World");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
