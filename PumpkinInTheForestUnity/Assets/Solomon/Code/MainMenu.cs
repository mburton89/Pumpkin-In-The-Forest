using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public MainMenu Instance;

    public List<Button> buttons;
    public List<string> scenesForButtons;

    public void Start()
    {
        Instance = this;

        if (scenesForButtons.Count < buttons.Count)
        {
            print("Not all buttons have their scene applied.");
            int nullsToAdd = buttons.Count - scenesForButtons.Count;

            for (int i = 0; i < nullsToAdd; i++)
            {
                scenesForButtons.Add(null);
            }
        }

        if (scenesForButtons.Count > buttons.Count)
        {
            print("Error, not enough buttons.");
        }
        else 
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                string temp = scenesForButtons[i];
                buttons[i].onClick.AddListener(delegate { LoadScene(temp); });
            }
        }
    }

    public void LoadScene(string sceneName)
    {
        if (sceneName == null)
        {
            print("There is no scene assigned to this button.\n");
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
