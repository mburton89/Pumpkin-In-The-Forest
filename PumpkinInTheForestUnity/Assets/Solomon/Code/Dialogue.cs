using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour, ISerializationCallbackReceiver
{
    public static Dialogue Instance;
    //This allows the user to choose between dialogue in the script, or heir custom dialogue.

    //This dictionary is not required, it is optional to edit dialogue straight from the editor.
    [SerializeField]
    public Dictionary<int, List<string>> dialogue;

    [SerializeField]
    public struct tempTester
    {
        int key;
        string value;
        string name;
    }
    [HideInInspector] public const string Pumpkin = "Pumpkin";
    [HideInInspector] public const string Lesley = "Lesley";

    public void OnBeforeSerialize()
    {}

    public void OnAfterDeserialize()
    { }

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UseDefaultDialogue(bool use = true)
    {
    }

    //Wrapper functions to access dialogue may be added to streamline the experience.  Subindexs allow for alternative text.
    public void CallDialogue(int index, bool trigger = false, int subIndex = 0, bool defaultText = true)
    {
        DialogueSystem.Instance.setActivatePumpkinWhenFinished(true);

        if (trigger)
        {
            DialogueSystem.Instance.simulate();
        }
            switch (index)
            {
                case 0:
                    if (subIndex == 0)
                    {
                        DialogueSystem.Instance.showText("Pumpkin! Pumpkin! This should not be here.", true, Pumpkin);
                    }
                    else if (subIndex == 1)
                    {
                        DialogueSystem.Instance.showText("Pumpkin! Pumpkin! This definately should not be here.", true, Pumpkin);
                    }
                    break;

                case 1:    //Pumpkin finds enough twigs for the ladder.
                    if (subIndex == 0)
                    {
                        DialogueSystem.Instance.showText("There. That should be enoguh twigs. Now for the tree sap.", true, Pumpkin);
                    }
                    else if (subIndex == 1)
                    {
                        DialogueSystem.Instance.showText("There. That should be enoguh sap. Now for the twigs.", true, Pumpkin);
                    }
                    break;

                case 2:    //Pumpkin finds the right amount of sap for the ladder.
                    DialogueSystem.Instance.showText("Excellent! Now all I have to do is combine the twigs and the tree sap. That should allow me to make it over the branch.", true, Pumpkin);
                    break;

                case 3:   //Pumpkin makes it over the log.
                    DialogueSystem.Instance.deactivatePumpkin();
                    DialogueSystem.Instance.showText("No turning back now. I hope I can find someone who can help me get home.", true, Pumpkin);
                    break;

                case 4:   //Pumpkin meets Lesley
                    DialogueSystem.Instance.showText("H-Hello? Can you help me? My name is Pumpkin and I am terribly lost!", false, Pumpkin);
                    DialogueSystem.Instance.showText("Well hello there! Name's Lesley! I was born in these woods and can usually get around them just fine.", false, Lesley);
                    DialogueSystem.Instance.showText("Aren't you that baby squirrel from the Huey drey on the edge of the forest?", false, Lesley);
                    DialogueSystem.Instance.showText("Wll I'm not sure what a drey or a Huey is, but I live in a burrow on the edge of the forest with two tall creatures. Can you help me get back home?", false, Pumpkin);
                    DialogueSystem.Instance.showText("Well sure! I know the way! But first we gotta get back to the Talkabout Tree  and speak with Bradley. From there we can get you back to your burrow.", false, Lesley);
                    DialogueSystem.Instance.showText("R-really? Thank you! Let's get going!", false, Pumpkin);
                    DialogueSystem.Instance.showText("Therein lies the issue. Seems the Order of Enigma has set up some kind of trap to keep critters from getting through to the Talkabout Tree.", false, Lesley);
                    DialogueSystem.Instance.showText("They used a bunch of vines and such to block the way with logs. Gonna need someone to hit the pullies in order to bring them down.", true, Lesley);

                break;

                case 5:   //Lesley's dialogue while the pumpkin searches for the slingshot materials.
                    DialogueSystem.Instance.showText("What we need is a slingshot. To make one, you will need to gather 2 twigs, 2 vines, and 2 sap.", false, Lesley);
                    DialogueSystem.Instance.showText("Okay, I can do that! I can find twigs on the ground and sap in the trees. Do you know where I can find vines?", false, Pumpkin);
                    DialogueSystem.Instance.showText("Vines can also be found in the trees and on some of the larger rocks.", true, Lesley);
                    break;
            }
    }
}
