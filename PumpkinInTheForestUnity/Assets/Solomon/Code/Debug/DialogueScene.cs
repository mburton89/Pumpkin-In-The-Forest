using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScene : MonoBehaviour
{
    bool displayText;
    // Start is called before the first frame update
    void Start()
    {
        displayText = false;
    }


    private void OnCollisionEnter(Collision collision)
    {
        displayText = true;
        //Used for debugging ---- print("Entered");
    }
    private void OnCollisionExit(Collision collision)
    {
        //Used for debugging ---- print("Bye my friend");
        displayText = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (displayText == true)
        {
            if (Input.GetKeyDown(DialogueSystem.Instance.interactKey))
            {
                Dialogue();
            }
        }

        
    }

    public void Dialogue()
    {
        //Used for debugging ---- print("The interact key has been pressed.");
        DialogueSystem.Instance.showText("Hello friend", false, "Pumpkin");
        DialogueSystem.Instance.showText("Hello Pumpkin!", false, "Friend");
        DialogueSystem.Instance.showText("Today is a great day!", false, "Pumpkin");
        DialogueSystem.Instance.showText("Amen to that!", false, "Friend");
        DialogueSystem.Instance.showText("Well, I'll see you later.", false);
        DialogueSystem.Instance.showText("Ok, See ya' later friend!", true, "Pumpkin");
    }
}
