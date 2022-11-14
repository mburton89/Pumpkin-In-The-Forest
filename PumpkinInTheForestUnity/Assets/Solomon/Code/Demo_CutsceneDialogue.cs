using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Demo_CutsceneDialogue : MonoBehaviour
{
    bool startPlayer;

    // Start is called before the first frame update
    void Start()
    {
        startPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueSystem.Instance.isFinished() && startPlayer)
        {
            TimelineController.Instance.playTimeline();
            startPlayer = false;
        }
    }

    public void democutscenedialogue(int dialogueNumber)
    {
        TimelineController.Instance.pauseTimeline();

        switch (dialogueNumber)
        {
            case 1:
                DisableObject.Instance.disableObject();
                DialogueSystem.Instance.simulate();
                DialogueSystem.Instance.showText("Hello? I-Is anybody there? Hello?", false, "Pumpkin");
                DialogueSystem.Instance.showText("Where am I? How did I get here?", true, "Pumpkin");
                startPlayer = true;
                break;

            case 2:
                TimelineController.Instance.pauseTimeline();

                DialogueSystem.Instance.simulate();
                DialogueSystem.Instance.showText("I need to find something to help me get over this branch.", false, "Pumpkin");
                DialogueSystem.Instance.showText("...", false, "Pumpkin");
                DialogueSystem.Instance.showText("I should be able to push that rock over to the branch and use it to climb over it!", true, "Pumpkin");
                startPlayer = true;
                break;

            case 3:
                DialogueSystem.Instance.showText("I need some sort of ramp or ladder to make it all the way over this branch. I will need some twigs and some tree sap to make one. I'm sure I can find both of those items somewhere in this clearing.");
                break;

        }
    }

    public void activatePumpkin()
    {
        GameObject tempPlayer = FindObjectOfType<Pumpkin_Movement_RB>().gameObject;
        tempPlayer.GetComponent<Pumpkin_Movement_RB>().enabled = true;
        tempPlayer.GetComponent<CapsuleCollider>().enabled = true;
        tempPlayer.GetComponent<Rigidbody>().useGravity = true;
        print("This should be a success.");
    }

    public void deactivatePumpkin()
    {
        GameObject tempPlayer = FindObjectOfType<Pumpkin_Movement_RB>().gameObject;
        tempPlayer.GetComponent<Pumpkin_Movement_RB>().enabled = false;
        tempPlayer.GetComponent<CapsuleCollider>().enabled = false;
        tempPlayer.GetComponent<Rigidbody>().useGravity = false;
        print("This shuld be another success.");
    }

}
