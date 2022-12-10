using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCaller : MonoBehaviour
{

    public int index;
    public bool dontUseDialogue;
    public bool isTrigger;
    public bool useColliderTag;
    public string CollidersTag;
    public bool destroyAfterFirstUse;
    public bool RemoveWhenDestroyed;
    //Add this in once dialogue can be edited from the unity editor.

    [HideInInspector] public int subIndex;  //This may be used if the dialogue needs to be better categorized. It is not being used as of right now.

    private bool used;

    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        used = false;

        //Dialogue.Instance.UseDefaultDialogue(true);  //This should be removed once dialogue can be edited in the unity editor.
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
        if (!dontUseDialogue)
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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!dontUseDialogue)
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

}
