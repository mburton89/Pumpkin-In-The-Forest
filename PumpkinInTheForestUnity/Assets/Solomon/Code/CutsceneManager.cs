using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//There should only be one scene active at a time.
//If there is more than one scene open at a time, each scene may not be closed and/or exited properly.
public class CutsceneManager : MonoBehaviour
{
    public static CutsceneManager Instance;

    public Animator cinematicAnimations;

    private bool shouldCheck = false;        //Tells if the cutscene manager should check for active scenes.

    private List<string> scenesToStop;

    private void Awake()
    {
        Instance = this;

        scenesToStop = new List<string> { };

        if (shouldCheck)
        {
            CheckScenes();
        }

    }


    public void PlayScene(string title)
    {
        switch (title)
        {
            case "Intro_Scene":
                cinematicAnimations.SetBool("Intro_Scene", true);
                shouldCheck = true;
                scenesToStop.Add("Intro_Scene");
                break;

            default:
                break;
        }
    }

    //Stop scene is private because it should not be directly called.
    private void StopScene(string title)
    {
        cinematicAnimations.SetBool(title, false);
    }

    private void CheckScenes()
    {
        introScene();
        //The other scenes will be listed below here.
    }

    private void introScene()
    {

    }

    //This destructor is not very necessary, it just makes sure all of the animations are stopped before the game closes.
    //This is probably all ready done by unity, so this is just some safe guarding.
    ~CutsceneManager()
    {
        if (scenesToStop.Count > 0)
        {
            foreach (string scene in scenesToStop)
            {
                StopScene(scene);
            }
        }
    }

}
