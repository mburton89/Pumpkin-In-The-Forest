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
        //print("Colliding: " + colliding);
        if (colliding && Input.GetKeyDown(DialogueSystem.Instance.interactKey))
        {
            Dialogue.Instance.CallDialogue(5, false);

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
