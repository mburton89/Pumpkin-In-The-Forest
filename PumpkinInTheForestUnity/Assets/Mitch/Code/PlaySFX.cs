using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySFX : MonoBehaviour
{
    public AudioSource birdsChirping;
    public AudioSource bushRustle;
    public AudioSource craftingComplete;
    public AudioSource dialogueVoice1;
    public AudioSource dialogueVoice2;
    public AudioSource dialogueVoice3;
    public AudioSource dialogueVoice4;
    public AudioSource footstep1;
    public AudioSource footstep2;
    public AudioSource footstep3;
    public AudioSource footstep4;
    public AudioSource pumpkinJump;
    public AudioSource wind;

    public void PlayBirdsChirping()
    {
        birdsChirping.Play();
    }

    public void PlayBushRustle()
    {
        bushRustle.Play();
    }

    public void PlayCraftingComplete()
    {
        craftingComplete.Play();
    }

    public void PlayDialogueVoice1()
    {
        dialogueVoice1.Play();
    }

    public void PlayDialogueVoice2()
    {
        dialogueVoice2.Play();
    }

    public void PlayDialogueVoice3()
    {
        dialogueVoice3.Play();
    }

    public void PlayDialogueVoice4()
    {
        dialogueVoice4.Play();
    }

    public void PlayFootstep1()
    {
        footstep1.Play();
    }

    public void PlayFootstep2()
    {
        footstep2.Play();
    }

    public void PlayFootstep3()
    {
        footstep3.Play();
    }

    public void PlayFootstep4()
    {
        footstep4.Play();
    }

    public void PlayPumpkinJump()
    {
        pumpkinJump.Play();
    }

    public void PlayWind()
    {
        wind.Play();
    }
}
