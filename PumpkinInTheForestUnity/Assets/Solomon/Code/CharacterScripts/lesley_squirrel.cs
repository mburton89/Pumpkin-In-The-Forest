using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lesley_squirrel : MonoBehaviour
{
    bool colliding;
    // Start is called before the first frame update
    void Start()
    {
        colliding = false;
    }

    // Update is called once per frame
    void Update()
    {
        print("Colliding: " + colliding);
        if (colliding && Input.GetKeyDown(DialogueSystem.Instance.interactKey))
        {
            DialogueSystem.Instance.showText("Hello Lesley!", false, "Pumpkin");
            DialogueSystem.Instance.showText("Hello Pumpkin!", false, "Lesley");
            DialogueSystem.Instance.showText("This seems to be working correctly to me.", false, "Pumpkin");

            if (DialogueSystem.Instance.isFinished())    //yes this is possible. Dynamic NPC dialogue.
                DialogueSystem.Instance.showText("It seems like this already happened. hmm...", false, "Pumpkin");

            DialogueSystem.Instance.showText("Yep, well, Bye", false, "Lesley");
            DialogueSystem.Instance.showText("Bye", true, "Pumpkin");

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        colliding = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        colliding = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        colliding = false;
    }

    private void OnTriggerExit(Collider other)
    {
        colliding = false;
    }
}
