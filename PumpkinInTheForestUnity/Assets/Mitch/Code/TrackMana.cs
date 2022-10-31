using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrackMana : MonoBehaviour
{
    [SerializeField] private Animator musicAnimationController;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            musicAnimationController.SetBool("fadeOut", true);
           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            musicAnimationController.SetBool("fadeOut", false);
        }
    }


    }

}

