using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialgueCode : MonoBehaviour
{
    public GameObject TextBox;
    public TextMeshProUGUI dialogue;
    public List<string> allDialogue;
    public int maxLines;


    private const int maxCharsPerLine = 77;
    private int numberOfLines;
    private int currentLine;
    private int currentBox;
    private List<bool> dialogueToShow;
    private bool showingDialogue;
    private bool nextBox;
    private string currentDialogue;
    private string currentDialogueShown;

    // Start is called before the first frame update
    void Start()
    {
        currentBox = 0;
        nextBox = false;
        showingDialogue = false;
        TextBox.SetActive(false);

        for (int i = 0; i < allDialogue.Count; i++)
        {
            dialogueToShow.Add(false);
        }

        dialogueToShow[0] = true;  //0 is the default line of text for the character.
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (showingDialogue == true)
            {
                if (nextBox == true)
                {
                    currentBox++;

                }
            }
            else
            {
                TextBox.SetActive(true);
                showingDialogue = true;
                currentLine = 1;
                currentBox = 1;

                for (int i = 0; i < dialogueToShow.Count; i++)
                {
                    if (dialogueToShow[i] == true)
                    {
                        currentDialogue = allDialogue[i];
                        break;
                    }
                }
            }

            if (currentBox == -1)
            {
                TextBox.SetActive(false);
                showingDialogue = false;
                currentLine = 0;
                currentBox = 0;
            }
            else
            {
                int startingNum = 308 * currentBox;
                int number = (dialogueToShow.Count) > (startingNum + 308) ? 308 : (dialogueToShow.Count - startingNum);

                currentDialogueShown = currentDialogue.Substring(startingNum, number);

                dialogue.SetText(currentDialogueShown);
            }
        }

    }
}
