using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCaller : MonoBehaviour
{

    public int index;
    public bool isTrigger;
    public bool useColliderTag;
    public string CollidersTag;
    public bool destroyAfterFirstUse;
    public bool RemoveWhenDestroyed;

    [HideInInspector] public int subIndex;  //This may be used if the dialogue needs to be better categorized. It is not being used as of right now.

    private bool used;

    // Start is called before the first frame update
    void Start()
    {
        used = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (destroyAfterFirstUse && used)
        {
            if (DialogueSystem.Instance.isFinished())
            {
                Object.Destroy((RemoveWhenDestroyed ? gameObject : this));
            }
        }
    }

    public void changeDialogue(int newIndex, bool newIsTrigger)
    {
        index = newIndex;
        isTrigger = newIsTrigger;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (useColliderTag)
        {
            if (other.tag == CollidersTag)
            {
                Dialogue.Instance.CallDialogue(index, isTrigger);
                used = true;
            }
        }
        else
        {
            Dialogue.Instance.CallDialogue(index, isTrigger);
            used = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (useColliderTag)
        {
            if (collision.gameObject.tag == CollidersTag)
            {
                print("Entered");
                Dialogue.Instance.CallDialogue(index, isTrigger);
                used = true;
            }
        }
        else
        {
            Dialogue.Instance.CallDialogue(index, isTrigger);
            used = true;
        }
    }

}
