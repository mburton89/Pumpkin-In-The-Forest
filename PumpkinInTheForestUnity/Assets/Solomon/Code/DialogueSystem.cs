//******************************
//
//    Name: Solomon Halll
//    TODO: Optimize the code to run better and faster.
//
//******************************

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    //This is a singleton class.
    #region Dialogue System Variables
    //Dialogue system variables
    //Public Variables
    public static DialogueSystem Instance;

    public GameObject TextBox;
    public TextMeshProUGUI dialogue;
    
    public int maxCharactersPerLine = 77;
    public int maxLines = 4;


    //Private Variables
    private const int maxCharsPerLine = 77;

    private int currentBox;                   //This tells the number of the current dialogue box being displayed.

    private bool showingDialogue;             //  --Set true for the dialogue box to appear, and vice versa.
    private bool nextBox;                     //  --Tells if there will be another box with dialogue in it.
    private bool waitForNextFrame;
    
    private string currentDialogue;           //  --The full dialogue that should be displayed.
    private string currentDialogueShown;      //  --The dialogue that is being displayer to the user in the current dialogue box.
    #endregion

    #region Pre-Coded dialogue variables
    //Pre-coded dialogue variables
    //public variables
    //public List<string> allDialogue;  --This is for pre-coded dialogue.

    //private variables
    //private int currentLine;                --This may be used to develop the dialogue even further.
    //private int numberOfLines;              --This may also be used to further develop the dialogue code.
    //private List<bool> dialogueToShow;      --This is used for pre-coded dialogue.
    #endregion

    /* The dialogue Box (Documentation)
     * The dialogue box variables are used to decide which and how many characters are being displayed to the screen at the current moment.
     * There is only one dialogue box as of right now.
     * if currentBox is set to -1, that exits the dialogue box and hides it.
     * Any other number will be included in a calculation to decide what dialogue to disp-lay to the screen.
     */

    /* Dialogue System vs. Pre-Dialogue (Docummentation)
     * 
     * ---- Dialogue System ----
     * The dialogue system can be called from any object as long as this script is attached to an object in the scene.
     * Custom text mmust pre provided when callig the dialogue system.
     * Example: DialogueSystem.Instance.ShowText("Hello World");
     * Example Use: The player gets hit and they say, "Ouch!";
     * 
     * ---- Pre-Dialogue ----
     * The pre-dialogue will be set from the dialogue class, or this class (DialogueSystem). 
     * This systemm is a work in progress, though here are the plans.
     * This system still processes all of the dialogue, though another object will already have the text;
     * Eaxmple Use: If every player in the game says "Ouch!", one object could hold this text and display it rather than
     * * The same text being typed over and over again using DialogueSystem.Instance.ShowText("Ouch!");
     * 
     */

    // Start is called before the first frame update
    void Start()
    {
        //Dialogue System
        Instance = this;

        TextBox.SetActive(false);

        currentBox = 0;
        
        showingDialogue = false;
        nextBox = false;
        waitForNextFrame = false;


        //Pre-Coded dialogue system
        /*  --This is for pre-coded dialogue.
        
        for (int i = 0; i < allDialogue.Count; i++)
        {
            dialogueToShow.Add(false);
        }

        dialogueToShow = new List<bool>();
        dialogueToShow[0] = true;  //0 is the default line of text for the character.
        */
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if ((showingDialogue == true) && (waitForNextFrame == false))
            {
                if (nextBox == true)
                {
                    currentBox++;
                }
                else
                {
                    currentBox = -1;
                }
            }

            if (currentBox == -1)
            {
                print("This thing is working perfectly");

                TextBox.SetActive(false);
                showingDialogue = false;
                //currentLine = 0;  --Used with the pre-coded dialoogue.
                currentBox = 0;
            }
            else
            {
                int maxChars = (maxCharactersPerLine * maxLines);
                int startingNum = maxChars * currentBox;
                //int startingNum = 308 * currentBox;

                int number = (currentDialogue.Length) > (startingNum + maxChars) ? maxChars : (currentDialogue.Length - startingNum);

                if (number == maxChars)
                {
                    nextBox = true;
                }
                else
                {
                    nextBox = false;
                }

                currentDialogueShown = currentDialogue.Substring(startingNum, number);

                print("Max Chars: " + maxChars);
                print("Current Dialogue:" + currentDialogue + ",,,Length: " + currentDialogue.Length);
                print("Current DialogueShown:" + currentDialogueShown + ",,,Length: " + currentDialogueShown.Length);
                dialogue.SetText(currentDialogueShown);
                print("Line count: " + dialogue.textInfo.lineCount);
            }

        }

        waitForNextFrame = false;
    }

    public void showText(string text)
    {
        if (showingDialogue == false)
        {
            TextBox.SetActive(true);
            showingDialogue = true;
            //currentLine = 1;  --Used with the pre-coded dialogue
            currentBox = 0;

            currentDialogue = text;
            waitForNextFrame = true;

            /*  --This is for pre-coded dialogue.
            for (int i = 0; i < dialogueToShow.Count; i++)
            {
                if (dialogueToShow[i] == true)
                {
                    currentDialogue = allDialogue[i];
                    break;
                }
            }
            */
        }
    }

}
