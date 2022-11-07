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
                DialogueSystem.Instance.showText("I need to find something to help me get ove the branch.", true, "Pumpkin");
                startPlayer = true;
                break;
        }
    }

}
