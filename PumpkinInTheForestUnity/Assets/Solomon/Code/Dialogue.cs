using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour, ISerializationCallbackReceiver
{
    public static Dialogue Instance;
    //This allows the user to choose between dialogue in the script, or heir custom dialogue.
    public static bool useScriptDialogue;

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
    
    //Wrapper functions to access dialogue may be added to streamline the experience.  Subindexs allow for alternative text.
    public void CallDialogue(int index, bool trigger = false, int subIndex = 0, bool defaultText = true)
    {
        if (trigger)
        {
            DialogueSystem.Instance.simulate();
        }

        if ((!useScriptDialogue || !defaultText) && (index < dialogue.Count))
        {
            for (int i = 0; i < dialogue.Count; i++)
            {
                if (i == (dialogue.Count - 1))
                {
                    DialogueSystem.Instance.showText(dialogue[index][i], true);
                }
                else
                {
                    DialogueSystem.Instance.showText(dialogue[index][i], false);
                }
            }
        }
        else
        {

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
            }
        }
    }
}
